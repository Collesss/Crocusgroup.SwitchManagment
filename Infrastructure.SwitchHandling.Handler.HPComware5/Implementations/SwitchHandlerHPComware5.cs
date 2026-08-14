using Application.SwitchHandling.Handler.Exceptions;
using Application.SwitchHandling.Handler.Exceptions.Enums;
using Application.SwitchHandling.Handler.Interfaces;
using Application.SwitchHandling.Handler.Models;
using Renci.SshNet;
using Renci.SshNet.Common;
using SwitchManagment.API.SwitchService.Extensions;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Infrastructure.SwitchHandling.Handler.HPComware5.Implementations
{
    public class SwitchHandlerHPComware5 : ISwitchHandler
    {
        private static readonly Regex SystemViewPromtShellRegex = new Regex(@"^\[[^\[\]]+\]", RegexOptions.Multiline);

        public async Task<SwitchInfo> GetSwitchInfo(ConnectConfig connectConfig, CancellationToken cancellationToken = default)
        {
            ValidateConfig(connectConfig);

            SwitchInfo switchInfo = new SwitchInfo { IpOrName = connectConfig.IpOrName };

            await CommonShellStream(shellStream =>
            {
                switchInfo.Vlans = GetVlans(shellStream);
                switchInfo.Ports = GetPorts(shellStream);
            }, connectConfig, cancellationToken);

            return switchInfo;
        }

        public async Task ConfigurePort(PortConfigAccess portConfig, CancellationToken cancellationToken = default)
        {
            ValidateConfig(portConfig);

            await CommonShellStream(shellStream =>
            {
                SetAccessVlan(shellStream, portConfig.InterfaceName, portConfig.AccessVlan);
            }, portConfig, cancellationToken);
        }

        public async Task ConfigurePort(PortConfigTrunk portConfig, CancellationToken cancellationToken = default)
        {
            ValidateConfig(portConfig);

            await CommonShellStream(shellStream =>
            {
                SetTrunckVlans(shellStream, portConfig.InterfaceName, portConfig.TrunkVlans);
            }, portConfig, cancellationToken);
        }



        #region help_methods

        #region validate
        private void ValidateConfig(ConnectConfig config)
        {
            ArgumentNullException.ThrowIfNull(config);
            ArgumentException.ThrowIfNullOrWhiteSpace(config.IpOrName);
            ArgumentException.ThrowIfNullOrWhiteSpace(config.Login);
            ArgumentNullException.ThrowIfNull(config.Password);
            ArgumentNullException.ThrowIfNull(config.SuperPassword);
        }

        private void ValidateConfig(PortConfig config)
        {
            ValidateConfig(config as ConnectConfig);

            ArgumentException.ThrowIfNullOrWhiteSpace(config.InterfaceName);
        }

        private void ValidateConfig(PortConfigTrunk config)
        {
            ValidateConfig(config as PortConfig);

            ArgumentNullException.ThrowIfNull(config.TrunkVlans);

            if (!config.TrunkVlans.All(vlan => vlan > 0))
                throw new ArgumentException("VLAN cant be less 1.");

            /*
            if (config.TrunkVlans.CountBy(vlan => vlan).Any(vlanCount => vlanCount.Value > 1))
                throw new ArgumentException("VLAN list can be unique.");
            */

            if (config.TrunkVlans.GroupBy(vlan => vlan).Any(vlanGroup => vlanGroup.Count() > 1))
                throw new ArgumentException("VLAN list can be unique.");

            /*
            if (config.TrunkVlans.Any(vlan => config.TrunkVlans.Count(vl => vlan == vl) > 1))
                throw new ArgumentException("VLAN list can be unique.");
            */
        }

        private void ValidateConfig(PortConfigAccess config)
        {
            ValidateConfig(config as PortConfig);

            if (config.AccessVlan < 1)
                throw new ArgumentException("VLAN cant be less 1.");
        }
        #endregion

        private async Task<(SshClient sshClient, ShellStream shellStream)> GetConnectionAndShell(string ipOrName, string login, string password, string superPassword, CancellationToken cancellationToken = default)
        {
            SshClient sshClient = await OpenConnect(ipOrName, login, password, cancellationToken);

            ShellStream shellStream = sshClient.CreateShellStreamNoTerminal();

            EnterSuperPassSystemViewAndDisScreenLen(shellStream, superPassword);

            return (sshClient, shellStream);
        }

        private async Task<SshClient> OpenConnect(string ipOrName, string login, string password, CancellationToken cancellationToken = default)
        {
            SshClient sshClient = new SshClient(ipOrName, 22, login, password);

            try
            {
                await sshClient.ConnectAsync(cancellationToken);
            }
            catch (SshAuthenticationException e) when (e.Message == "Permission denied (password).")
            {
                throw new SwitchHandlerException(SwitchHandlerErrorType.WrongLoginOrPass, e);
            }
            catch (SocketException e)
            {
                throw new SwitchHandlerException(SwitchHandlerErrorType.HostNotExistOrUnreac, e);
            }

            return sshClient;
        }

        private IEnumerable<int> GetOnlyVlanNums(ShellStream shellStream)
        {
            shellStream.WriteLineAndExpect("display vlan");
            shellStream.Expect("The following VLANs exist:\r\n");

            string vlns = shellStream.Expect("\n");

            shellStream.Expect(SystemViewPromtShellRegex);

            return Regex.Matches(vlns, @"\d+").Select(match => Int32.Parse(match.Value)).ToArray();
        }

        private IEnumerable<SwitchVlan> GetVlans(ShellStream shellStream)
        {
            Regex vlanRegex = new Regex(@"VLAN ID: (?<vlan_id>\d+)[?<=\d\D]+?Description: (?<description>[^\r\n]+)[?<=\d\D]+?Name: (?<name>[^\r\n]+)");

            shellStream.WriteLine("display vlan all");
            shellStream.Expect("display vlan all");

            string rawOutputVlanInfo = shellStream.Expect(SystemViewPromtShellRegex);

            return vlanRegex.Matches(rawOutputVlanInfo).Select(match => new SwitchVlan
            {
                Vlan = int.Parse(match.Groups["vlan_id"].Value),
                Name = match.Groups["name"].Value,
                Description = match.Groups["description"].Value
            }).ToArray();
        }

        private IEnumerable<SwitchPort> GetPorts(ShellStream shellStream)
        {
            Regex interfaceRegex = new Regex(@"(?<interface>[^ ]+) current state: (?<state>[^\r\n]+)[\d\D]+?Description: (?<description>[^\r\n]+)[\d\D]+?Port link-type: (?:(?<link_type>access)[\d\D]+?Untagged VLAN ID : (?<vlan>\d+)|(?<link_type>trunk)[\d\D]+?VLAN permitted:(?: (?:(?<vlan_range>(?<from>\d+)-(?<to>\d+))|(?<vlan>\d+))[^,\n]*[,\n]?)+|(?<link_type>.+))");

            shellStream.WriteLineAndExpect("display interface");

            string rawOutputInterfaceInfo = shellStream.Expect(SystemViewPromtShellRegex);

            return interfaceRegex.Matches(rawOutputInterfaceInfo)
                .Select(match => new SwitchPort
                {
                    Interface = match.Groups["interface"].Value,
                    Description = match.Groups["description"].Value,
                    Status = match.Groups["state"].Value switch
                    {
                        "DOWN" => SwitchPortStatus.Down,
                        "UP" => SwitchPortStatus.Up,
                        _ => SwitchPortStatus.Disabled
                    },
                    Type = match.Groups["link_type"].Value switch
                    {
                        "access" => SwitchPortType.Access,
                        "trunk" => SwitchPortType.Trunk,
                        _ => SwitchPortType.Unknown
                    },
                    Vlans = match.Groups["vlan"].Captures.Select(matchVlan => int.Parse(matchVlan.Value)).ToArray()
                }).ToArray();
        }

        private void EnterSuperPassSystemViewAndDisScreenLen(ShellStream shellStream, string superPassword)
        {
            shellStream.WriteLine("_cmdline-mode on");
            shellStream.WriteLine("Y");
            shellStream.WriteLine(superPassword);

            shellStream.Expect(new ExpectAction("Error: Invalid password.", _ => throw new SwitchHandlerException(SwitchHandlerErrorType.WrongSuperPass)),
                new ExpectAction("Warning: Now you enter an all-command mode for developer's testing, some commands may affect operation by wrong use, please carefully use it with our engineer's direction.", _ => { }));

            shellStream.WriteLine("screen-length disable");

            shellStream.WriteLineAndExpect("system-view");
            Wait(shellStream);
        }

        private void SetAccessVlan(ShellStream shellStream, string interfaceName, int vlan)
        {
            EnterInterface(shellStream, interfaceName);

            CheckVlanExsit(shellStream, vlan);

            SetLinkType(shellStream, LinkType.access);

            shellStream.WriteLineAndExpect($"port access vlan {vlan}");

            Wait(shellStream);
        }

        private void SetTrunckVlans(ShellStream shellStream, string interfaceName, IEnumerable<int> vlans)
        {
            EnterInterface(shellStream, interfaceName);

            CheckVlanExsit(shellStream, vlans.ToArray());

            SetLinkType(shellStream, LinkType.trunk);

            shellStream.WriteLineAndExpect("undo port trunk permit vlan all");

            if (vlans.Any())
                shellStream.WriteLineAndExpect($"port trunk permit vlan {string.Join(' ', vlans)}");

            Wait(shellStream);
        }

        private void EnterInterface(ShellStream shellStream, string interfaceName)
        {
            shellStream.WriteLineAndExpect($"interface {interfaceName}");

            shellStream.Expect(new ExpectAction("% Wrong parameter found at '^' position.", _ =>
                throw new SwitchHandlerException(SwitchHandlerErrorType.WrongInterface)),
                        new ExpectAction(SystemViewPromtShellRegex, _ => { }));
        }

        private void Wait(ShellStream shellStream) =>
            shellStream.Expect(SystemViewPromtShellRegex);

        private enum LinkType
        {
            access,
            trunk
        }

        private void SetLinkType(ShellStream shellStream, LinkType linkType)
        {
            shellStream.WriteLineAndExpect($"port link-type {Enum.GetName(linkType)}");

            shellStream.Expect(new ExpectAction("% Unrecognized command found at '^' position.", _ =>
                    throw new SwitchHandlerException(SwitchHandlerErrorType.WrongInterface)),
                            new ExpectAction(SystemViewPromtShellRegex, _ => { }));
        }

        private void CheckVlanExsit(ShellStream shellStream, params int[] vlans)
        {
            IEnumerable<int> vlansOnSwitch = GetOnlyVlanNums(shellStream);

            if (!vlans.All(vl => vlansOnSwitch.Any(vlOnSw => vl == vlOnSw)))
                throw new SwitchHandlerException(SwitchHandlerErrorType.VLANNotExist);
        }

        private async Task CommonShellStream(Action<ShellStream> action, ConnectConfig connectConfig, CancellationToken cancellationToken = default)
        {
            SshClient sshClient = null;
            ShellStream shellStream = null;

            try
            {
                (sshClient, shellStream) = await GetConnectionAndShell(connectConfig.IpOrName, connectConfig.Login, connectConfig.Password, connectConfig.SuperPassword, cancellationToken);

                action(shellStream);
            }
            catch (SwitchHandlerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SwitchHandlerException(SwitchHandlerErrorType.Unknown, ex);
            }
            finally
            {
                shellStream?.Dispose();
                sshClient?.Dispose();
            }
        }

        #endregion
    }
}
