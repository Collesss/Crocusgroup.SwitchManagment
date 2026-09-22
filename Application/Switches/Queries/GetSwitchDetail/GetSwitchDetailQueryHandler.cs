using Application.DbContext;
using MapsterMapper;
using Application.CurrentUserService.Security;
using Application.DbContext.Models;
using Application.Common.Query.Detail;

namespace Application.Switches.Queries.GetSwitchDetail
{
    [RequirePermission(Permissions.Switch.View)]
    public class GetSwitchDetailQueryHandler : CommonDetailQueryHandler<GetSwitchDetailQuery, SwitchDetailResponse, SwitchEntity>
    {
        public GetSwitchDetailQueryHandler(ISwitchManagmentDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
