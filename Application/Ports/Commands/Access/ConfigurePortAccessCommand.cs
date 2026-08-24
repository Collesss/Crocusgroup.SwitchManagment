using MediatR;

namespace Application.Ports.Commands.Access
{
    public class ConfigurePortAccessCommand : IRequest
    {
        public int SwitchId { get; set; }

        public string InterfaceName { get; set; }

        public int AccessVlan {  get; set; }
    }
}
