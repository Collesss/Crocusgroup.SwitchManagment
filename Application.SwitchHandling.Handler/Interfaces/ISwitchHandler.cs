using Application.SwitchHandling.Handler.Models;
using Application.SwitchHandling.Handler.Exceptions;

namespace Application.SwitchHandling.Handler.Interfaces
{
    public interface ISwitchHandler
    {
        /// <summary>
        /// Get VLANs and ports settings on a switch.
        /// </summary>
        /// <param name="connectConfig">Data for connecting to the switch.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="ArgumentException">Throw if params: connectConfig.IpOrName, connectConfig.Login; empty or contains only whitespaces.</exception>
        /// <exception cref="ArgumentNullException">Throw if params: connectConfig, connectConfig.IpOrName; is null.</exception>
        /// <exception cref="OperationCanceledException">Thrown if a cancellation was requested.</exception>
        /// <exception cref="SwitchHandlerException">Throw if an unknown error occurs.</exception>
        /// <exception cref="HostNotExistOrUnreachableSwitchHandlerException">Throw if host not exsits or unreachable.</exception>
        /// <exception cref="WrongLoginOrPassSwitchHandlerException">Throw if login or pass invalid.</exception>
        /// <exception cref="WrongSuperPassSwitchHandlerException">Throw if superpass invalid.</exception>
        /// <returns>List ports and vlans.</returns>
        public Task<SwitchInfo> GetSwitchInfo(ConnectConfig connectConfig, CancellationToken cancellationToken = default);

        //public Task ConfigurePort(PortConfig portConfig, CancellationToken cancellationToken = default);

        /// <summary>
        /// Configure the port as an access.
        /// </summary>
        /// <param name="portConfig">Data for connecting to the switch and settings for access port.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="ArgumentException">Throw if params: connectConfig.IpOrName, connectConfig.Login, portConfig.InterfaceName; empty or contains only whitespaces.</exception>
        /// <exception cref="ArgumentNullException">Throw if params: portConfig, portConfig.IpOrName, portConfig.InterfaceName; is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throw if param "portConfig.AccessVlan" less than 1 or great than 4095.</exception>
        /// <exception cref="OperationCanceledException">Thrown if a cancellation was requested.</exception>
        /// <exception cref="SwitchHandlerException">Throw if an unknown error occurs.</exception>
        /// <exception cref="HostNotExistOrUnreachableSwitchHandlerException">Throw if host not exsits or unreachable.</exception>
        /// <exception cref="WrongLoginOrPassSwitchHandlerException">Throw if login or pass invalid.</exception>
        /// <exception cref="WrongSuperPassSwitchHandlerException">Throw if superpass invalid.</exception>
        /// <exception cref="WrongInterfaceSwitchHandlerException">Throw if interface not exists.</exception>
        /// <exception cref="VLANNotExistSwitchHandlerException">Throw if vlan not exists.</exception>
        /// <returns></returns>
        public Task ConfigurePort(PortTrunkConfig portConfig, CancellationToken cancellationToken = default);


        /// <summary>
        /// Configure the port as an trunk.
        /// </summary>
        /// <param name="portConfig">Data for connecting to the switch and settings for trunk port.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="ArgumentException">Throw if params: connectConfig.IpOrName, connectConfig.Login; empty or contains only whitespaces.</exception>
        /// <exception cref="ArgumentNullException">Throw if params: portConfig, portConfig.IpOrName, portConfig.InterfaceName; is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throw if array "portConfig.TrunkVlans" contains vlan less than 1 or great than 4095.</exception>
        /// <exception cref="ArgumentException">Throw if params: connectConfig.IpOrName, connectConfig.Login; empty or contains only whitespaces 
        /// or if array "portConfig.TrunkVlans" contains duplicate vlan.</exception>
        /// <exception cref="OperationCanceledException">Thrown if a cancellation was requested.</exception>
        /// <exception cref="HostNotExistOrUnreachableSwitchHandlerException">Throw if host not exsits or unreachable.</exception>
        /// <exception cref="WrongLoginOrPassSwitchHandlerException">Throw if login or pass invalid.</exception>
        /// <exception cref="WrongSuperPassSwitchHandlerException">Throw if superpass invalid.</exception>
        /// <exception cref="WrongInterfaceSwitchHandlerException">Throw if interface not exists.</exception>
        /// <exception cref="VLANNotExistSwitchHandlerException">Throw if array "portConfig.TrunkVlans" contains not exists vlan.</exception>
        /// <returns></returns>
        public Task ConfigurePort(PortAccessConfig portConfig, CancellationToken cancellationToken = default);
    }
}