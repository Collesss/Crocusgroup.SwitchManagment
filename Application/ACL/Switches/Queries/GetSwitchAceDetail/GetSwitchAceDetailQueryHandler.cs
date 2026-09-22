using Application.Common.Query.Detail;
using Application.CurrentUserService.Security;
using Application.DbContext;
using Application.DbContext.Models.ACE.Switch;
using MapsterMapper;

namespace Application.ACL.Switches.Queries.GetSwitchAceDetail
{
    [RequirePermission(Permissions.ACL.Switch.View)]
    public class GetSwitchAceDetailQueryHandler(ISwitchManagmentDbContext dbContext, IMapper mapper) : 
        CommonDetailQueryHandler<GetSwitchAceDetailQuery, SwitchAceDetailResponse, SwitchAceEntity>(dbContext, mapper)
    {
    }
}
