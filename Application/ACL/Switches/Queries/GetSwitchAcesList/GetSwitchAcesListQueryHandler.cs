using Application.Common.Interfaces;
using Application.Common.Query.List;
using Application.DbContext;
using Application.DbContext.Models.ACE.Switch;
using MapsterMapper;

namespace Application.ACL.Switches.Queries.GetSwitchAcesList
{
    public class GetSwitchAcesListQueryHandler(ISwitchManagmentDbContext dbContext, IMapper mapper, IFilterApplier<SwitchAceFilter, SwitchAceEntity> filterApplier) : 
        CommonListQueryHandler<GetSwitchAcesListQuery, SwitchAcesListResponse, SwitchAceLookupDto, SwitchAceSortField, SwitchAceFilter, SwitchAceEntity>(dbContext, mapper, filterApplier)
    {
    }
}
