using Application.ACL.Vlans.Queries.GetVlanAcesList.Common;
using Application.ACL.Vlans.Queries.GetVlanAcesList.Filter;
using Application.ACL.Vlans.Queries.GetVlanAcesList.Response;
using Application.Common.Query.List;
using MediatR;

namespace Application.ACL.Vlans.Queries.GetVlanAcesList.Query
{
    /// <summary>
    /// Query for get list vlan aces.
    /// </summary>
    public class GetVlanAcesListQuery : CommonListQuery<VlanAceFilter, VlanAceSortField>, IRequest<VlanAceListResponse>
    {
    }
}
