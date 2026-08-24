using MediatR;

namespace Application.Ports.Commands.Trunk
{
    public class ConfigurePortTrunkCommand : IRequest
    {
        public int SwitchId { get; set; }

        public string InterfaceName { get; set; }

        public IEnumerable<int> TrunkVlans { get; set; }
    }
}
