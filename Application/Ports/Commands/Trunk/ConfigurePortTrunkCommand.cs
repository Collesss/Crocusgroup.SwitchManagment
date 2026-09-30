using Application.Ports.Commands.Common;
using MediatR;

namespace Application.Ports.Commands.Trunk
{
    public class ConfigurePortTrunkCommand : CommonConfigurePortCommand, IRequest
    {
        public IEnumerable<int> TrunkVlans { get; set; }
    }
}
