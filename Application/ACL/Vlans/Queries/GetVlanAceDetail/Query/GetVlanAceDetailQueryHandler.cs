using Application.ACL.Vlans.Queries.GetVlanAceDetail.Response;
using Application.Common.Query.Detail;
using Application.CurrentUserService.Security;
using Application.DbContext;
using Application.DbContext.Models.ACE.Vlan;
using MapsterMapper;

namespace Application.ACL.Vlans.Queries.GetVlanAceDetail.Query
{
    [RequirePermission(Permissions.ACL.Vlan.View)]
    public class GetVlanAceDetailQueryHandler(ISwitchManagmentDbContext dbContext, IMapper mapper) :
        CommonDetailQueryHandler<GetVlanAceDetailQuery, VlanAceDetailResponse, VlanAceEntity>(dbContext, mapper)
    {
    }
}
