using Application.Common.Commands.Delete;
using MediatR;

namespace Application.ACL.Vlans.Commands.Delete
{
    /// <summary>
    /// Command for delete vlan ace.
    /// </summary>
    public class DeleteVlanAceCommand : CommonDeleteCommand, IRequest
    {
    }
}
