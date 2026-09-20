using Application.Common.Commands;
using Application.CurrentUserService.Security;
using Application.DbContext;
using Application.DbContext.Models.ACE.Switch;
using MapsterMapper;

namespace Application.ACL.Switches.Commands.Add
{
    [RequirePermission(Permissions.ACL.Switch.Add)]
    public class AddSwitchAceCommandHandler(ISwitchManagmentDbContext dbContext, IMapper mapper) 
        : CommonAddComandHandler<AddSwitchAceCommand, SwitchAceEntity>(dbContext, mapper)
    {
    }
}