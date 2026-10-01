using Application.ACL.Common;
using Application.ACL.Vlans.Common;

namespace Application.ACL.Vlans.Queries.GetVlanAceDetail.Response
{
    public class VlanAceDetailResponse : CommonAceDto<VlanRigthsMask>
    {
        public int VlanId { get; set; }
    }
}
