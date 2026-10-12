using Application.ACL.Common;
using Application.ACL.Vlans.Common;

namespace Application.ACL.Vlans.Queries.GetVlanAcesList.Response
{
    public class VlanAceLookupDto : CommonAceDto<VlanRightsMask>
    {
        public int VlanId { get; set; }
    }
}
