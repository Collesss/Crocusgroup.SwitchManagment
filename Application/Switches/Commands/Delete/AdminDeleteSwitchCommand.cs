using MediatR;

namespace Application.Switches.Commands.Delete
{
    public class AdminDeleteSwitchCommand : IRequest
    {
        public int Id { get; set; }
    }
}
