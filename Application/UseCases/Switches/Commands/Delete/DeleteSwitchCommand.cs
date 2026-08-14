using MediatR;

namespace Application.UseCases.Switches.Commands.Delete
{
    public class DeleteSwitchCommand : IRequest
    {
        public int Id { get; set; }
    }
}
