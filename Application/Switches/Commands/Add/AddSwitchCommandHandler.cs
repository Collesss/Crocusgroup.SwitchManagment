using Application.Common.Commands.Add;
using Application.CurrentUserService.Security;
using Application.DbContext;
using Application.DbContext.Models;
using MapsterMapper;

namespace Application.Switches.Commands.Add
{
    [RequirePermission(Permissions.Switch.Add)]
    public class AddSwitchCommandHandler(ISwitchManagmentDbContext dbContext, IMapper mapper) : 
        CommonAddCommandHandler<AddSwitchCommand, SwitchEntity>(dbContext, mapper)
    {
    }
}
