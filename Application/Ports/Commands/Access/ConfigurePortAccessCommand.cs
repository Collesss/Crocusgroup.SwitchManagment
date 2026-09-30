using Application.Ports.Commands.Common;
using MediatR;

namespace Application.Ports.Commands.Access
{
    public class ConfigurePortAccessCommand : CommonConfigurePortCommand, IRequest
    {
        public int AccessVlan {  get; set; }
    }
}
