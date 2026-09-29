using Application.Common.Commands.Delete;
using MediatR;

namespace Application.ACL.Ports.Commands.Delete
{
    /// <summary>
    /// Command for delete port ace.
    /// </summary>
    public class DeletePortAceCommand : CommonDeleteCommand, IRequest
    {
    }
}
