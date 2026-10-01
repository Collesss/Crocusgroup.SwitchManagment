using Application.ACL.Ports.Queries.GetPortAcesList.Common;
using Application.ACL.Ports.Queries.GetPortAcesList.Filter;
using Application.ACL.Ports.Queries.GetPortAcesList.Response;
using Application.Common.Interfaces;
using Application.Common.Query.List;
using Application.DbContext;
using Application.DbContext.Models.ACE.Port;
using MapsterMapper;

namespace Application.ACL.Ports.Queries.GetPortAcesList.Query
{
    public class GetPortAcesListQueryHandler(ISwitchManagmentDbContext dbContext, IMapper mapper, IFilterApplier<PortAceFilter, PortAceEntity> filterApplier) : 
        CommonListQueryHandler<GetPortAcesListQuery, PortAcesListResponse, PortAceLookupDto, PortAceSortField, PortAceFilter, PortAceEntity>(dbContext, mapper, filterApplier)
    {
    }
}
