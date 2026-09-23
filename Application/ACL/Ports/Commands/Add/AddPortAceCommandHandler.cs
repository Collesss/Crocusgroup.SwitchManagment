using Application.Common.Commands;
using Application.CurrentUserService.Security;
using Application.DbContext;
using Application.DbContext.Models.ACE.Port;
using MapsterMapper;

namespace Application.ACL.Ports.Commands.Add
{
    [RequirePermission(Permissions.ACL.Port.Add)]
    public class AddPortAceCommandHandler(ISwitchManagmentDbContext dbContext, IMapper mapper) : 
        CommonAddComandHandler<AddPortAceCommand, PortAceEntity>(dbContext, mapper)
    {
    }
}
