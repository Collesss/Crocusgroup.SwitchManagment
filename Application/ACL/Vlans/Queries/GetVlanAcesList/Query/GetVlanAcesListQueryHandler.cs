using Application.ACL.Vlans.Queries.GetVlanAcesList.Common;
using Application.ACL.Vlans.Queries.GetVlanAcesList.Filter;
using Application.ACL.Vlans.Queries.GetVlanAcesList.Response;
using Application.Common.Interfaces;
using Application.Common.Query.List;
using Application.DbContext;
using Application.DbContext.Models.ACE.Vlan;
using MapsterMapper;

namespace Application.ACL.Vlans.Queries.GetVlanAcesList.Query
{
    public class GetVlanAcesListQueryHandler(ISwitchManagmentDbContext dbContext, IMapper mapper, IFilterApplier<VlanAceFilter, VlanAceEntity> filterApplier) :
        CommonListQueryHandler<GetVlanAcesListQuery, VlanAceListResponse, VlanAceLookupDto, VlanAceSortField, VlanAceFilter, VlanAceEntity>(dbContext, mapper, filterApplier)
    {
    }
}
