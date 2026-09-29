using Application.Common.Commands.Delete;
using MediatR;

namespace Application.ACL.Switches.Commands.Delete
{
    /// <summary>
    /// Command for delete switch ace.
    /// </summary>
    public class DeleteSwitchAceCommand : CommonDeleteCommand, IRequest
    {
    }
}
