using Application.ACL.Common;
using Application.ACL.Vlans.Common;

namespace Application.ACL.Vlans.Queries.GetVlanAcesList
{
    public class VlanAceLookupDto : CommonAceDto<VlanRigthsMask>
    {
        public int VlanId { get; set; }
    }
}
