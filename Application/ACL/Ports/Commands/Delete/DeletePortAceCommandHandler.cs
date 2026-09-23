using Application.Common.Commands;
using Application.CurrentUserService.Security;
using Application.DbContext;
using Application.DbContext.Models.ACE.Port;
using MapsterMapper;

namespace Application.ACL.Ports.Commands.Delete
{
    [RequirePermission(Permissions.ACL.Port.Delete)]
    public class DeletePortAceCommandHandler(ISwitchManagmentDbContext dbContext, IMapper mapper) 
        : CommonDeleteCommandHandler<DeletePortAceCommand, PortAceEntity>(dbContext, mapper)
    {
    }
}
