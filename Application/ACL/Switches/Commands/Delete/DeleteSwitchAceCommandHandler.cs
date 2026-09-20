using Application.Common.Commands;
using Application.CurrentUserService.Security;
using Application.DbContext;
using Application.DbContext.Models.ACE.Switch;
using MapsterMapper;

namespace Application.ACL.Switches.Commands.Delete
{
    [RequirePermission(Permissions.ACL.Switch.Delete)]
    public class DeleteSwitchAceCommandHandler(ISwitchManagmentDbContext dbContext, IMapper mapper) 
        : CommonDeleteCommandHandler<DeleteSwitchAceCommand, SwitchAceEntity>(dbContext, mapper)
    {
    }
}
