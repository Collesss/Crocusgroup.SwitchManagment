using Application.Common.Query.Detail;
using MediatR;

namespace Application.ACL.Vlans.Queries.GetVlanAceDetail
{
    /// <summary>
    /// Query for get detail vlan ace by Id.
    /// </summary>
    public class GetVlanAceDetailQuery : CommonDetailQuery, IRequest<VlanAceDetailResponse>
    {
    }
}
