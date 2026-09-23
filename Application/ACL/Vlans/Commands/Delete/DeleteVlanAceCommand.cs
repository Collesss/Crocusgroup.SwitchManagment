using MediatR;

namespace Application.ACL.Vlans.Commands.Delete
{
    /// <summary>
    /// Command for delete vlan ace.
    /// </summary>
    public class DeleteVlanAceCommand : IRequest
    {
        /// <summary>
        /// Id deleting vlan ace, cant be less 1.
        /// </summary>
        public int Id { get; set; }
    }
}
