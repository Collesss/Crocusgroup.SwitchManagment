using Application.ACL.Switches.Queries.GetSwitchAcesList.Common;
using Application.ACL.Switches.Queries.GetSwitchAcesList.Filter;
using Application.ACL.Switches.Queries.GetSwitchAcesList.Response;
using Application.Common.Interfaces;
using Application.Common.Query.List;
using Application.DbContext;
using Application.DbContext.Models.ACE.Switch;
using MapsterMapper;

namespace Application.ACL.Switches.Queries.GetSwitchAcesList.Query
{
    public class GetPortAcesListQueryHandler(ISwitchManagmentDbContext dbContext, IMapper mapper, IFilterApplier<SwitchAceFilter, SwitchAceEntity> filterApplier) : 
        CommonListQueryHandler<GetSwitchAcesListQuery, PortAcesListResponse, PortAceLookupDto, SwitchAceSortField, SwitchAceFilter, SwitchAceEntity>(dbContext, mapper, filterApplier)
    {
    }
}
