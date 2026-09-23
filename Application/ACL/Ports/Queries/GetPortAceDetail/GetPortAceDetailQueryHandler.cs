using Application.Common.Query.Detail;
using Application.CurrentUserService.Security;
using Application.DbContext;
using Application.DbContext.Models.ACE.Switch;
using MapsterMapper;

namespace Application.ACL.Ports.Queries.GetPortAceDetail
{
    [RequirePermission(Permissions.ACL.Port.View)]
    public class GetPortAceDetailQueryHandler(ISwitchManagmentDbContext dbContext, IMapper mapper) : 
        CommonDetailQueryHandler<GetPortAceDetailQuery, PortAceDetailResponse, SwitchAceEntity>(dbContext, mapper)
    {
    }
}
