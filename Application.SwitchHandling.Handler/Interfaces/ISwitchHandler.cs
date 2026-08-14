using Application.SwitchHandling.Handler.Models;

namespace Application.SwitchHandling.Handler.Interfaces
{
    public interface ISwitchHandler
    {
        public Task<SwitchInfo> GetSwitchInfo(ConnectConfig connectConfig, CancellationToken cancellationToken = default);

        //public Task ConfigurePort(PortConfig portConfig, CancellationToken cancellationToken = default);

        public Task ConfigurePort(PortConfigTrunk portConfig, CancellationToken cancellationToken = default);

        public Task ConfigurePort(PortConfigAccess portConfig, CancellationToken cancellationToken = default);
    }
}
