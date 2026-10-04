using Application.Common.Commands.Add;
using Application.CurrentUserService.Security;
using Application.DbContext;
using Application.DbContext.Models.ACE.Vlan;
using MapsterMapper;

namespace Application.ACL.Vlans.Commands.Add
{
    [RequirePermission(Permissions.ACL.Vlan.Add)]
    public class AddVlanAceCommandHandler(ISwitchManagmentDbContext dbContext, IMapper mapper) : CommonAddCommandHandler<AddVlanAceCommand, VlanAceEntity>(dbContext, mapper)
    {
    }
}
