using Application.Common.Query.List;
using MediatR;

namespace Application.ACL.Vlans.Queries.GetVlanAcesList
{
    /// <summary>
    /// Query for get list vlan aces.
    /// </summary>
    public class GetVlanAcesListQuery : CommonListQuery<VlanAceFilter, VlanAceSortField>, IRequest<VlanAceListResponse>
    {
    }
}
