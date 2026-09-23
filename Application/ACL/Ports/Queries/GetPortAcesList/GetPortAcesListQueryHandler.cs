using Application.Common.Interfaces;
using Application.Common.Query.List;
using Application.DbContext;
using Application.DbContext.Models.ACE.Port;
using MapsterMapper;

namespace Application.ACL.Ports.Queries.GetPortAcesList
{
    public class GetPortAcesListQueryHandler(ISwitchManagmentDbContext dbContext, IMapper mapper, IFilterApplier<PortAceFilter, PortAceEntity> filterApplier) : 
        CommonListQueryHandler<GetPortAcesListQuery, PortAcesListResponse, PortAceLookupDto, PortAceSortField, PortAceFilter, PortAceEntity>(dbContext, mapper, filterApplier)
    {
    }
}
