using Application.Common.Commands.Delete;
using Application.CurrentUserService.Security;
using Application.DbContext;
using Application.DbContext.Models.ACE.Switch;
using MapsterMapper;

namespace Application.ACL.Switches.Commands.Delete
{
    [RequirePermission(Permissions.ACL.Switch.Delete)]
    public class DeletePortAceCommandHandler(ISwitchManagmentDbContext dbContext, IMapper mapper) 
        : CommonDeleteCommandHandler<DeleteSwitchAceCommand, SwitchAceEntity>(dbContext, mapper)
    {
    }
}
