using Application.Common.Commands;
using Application.CurrentUserService.Security;
using Application.DbContext;
using Application.DbContext.Models.ACE.Vlan;
using MapsterMapper;

namespace Application.ACL.Vlans.Commands.Delete
{
    [RequirePermission(Permissions.ACL.Vlan.Delete)]
    public class DeleteVlanAceCommandHandler(ISwitchManagmentDbContext dbContext, IMapper mapper) : CommonDeleteCommandHandler<DeleteVlanAceCommand, VlanAceEntity>(dbContext, mapper)
    {
    }
}
