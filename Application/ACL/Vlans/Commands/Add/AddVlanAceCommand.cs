using Application.ACL.Common;
using Application.ACL.Vlans.Common;
using MediatR;

namespace Application.ACL.Vlans.Commands.Add
{
    /// <summary>
    /// Command for add vlan ace, adding the record must be unique based on a composite key consisting of the fields: SwitchId, GroupId and VlanId.
    /// </summary>
    public class AddVlanAceCommand : CommonAddAceCommand<VlanRigthsMask>, IRequest<int>
    {
        /// <summary>
        /// Id vlan, cant less than 1 or great than 4094
        /// </summary>
        public int VlanId {  get; set; }
    }
}
