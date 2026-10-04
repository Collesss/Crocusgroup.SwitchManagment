using Application.Common.Commands.Delete;
using MediatR;

namespace Application.Switches.Commands.Delete
{
    /// <summary>
    /// Command for remove switch.
    /// </summary>
    public class DeleteSwitchCommand : CommonDeleteCommand, IRequest
    {
    }
}
