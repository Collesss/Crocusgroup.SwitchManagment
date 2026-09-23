using Application.Common.Interfaces;
using Application.Common.Query.List;
using Application.DbContext;
using Application.DbContext.Models.ACE.Switch;
using MapsterMapper;

namespace Application.ACL.Switches.Queries.GetSwitchAcesList
{
    public class GetPortAcesListQueryHandler(ISwitchManagmentDbContext dbContext, IMapper mapper, IFilterApplier<SwitchAceFilter, SwitchAceEntity> filterApplier) : 
        CommonListQueryHandler<GetPortAcesListQuery, PortAcesListResponse, PortAceLookupDto, SwitchAceSortField, SwitchAceFilter, SwitchAceEntity>(dbContext, mapper, filterApplier)
    {
    }
}
