using Application.Common.Exceptions;
using Application.CurrentUserService.Interfaces;
using Application.CurrentUserService.Security;
using Application.DbContext;
using Application.DbContext.Models;
using Application.DbContext.Models.ACE.Port;
using Application.DbContext.Models.ACE.Vlan;
using Application.SwitchHandling.Handler.Models;
using Application.SwitchHandling.Provider.Interfaces;
using Mapster;
using MapsterMapper;
using MediatR;

namespace Application.Ports.Commands.Access
{
    [RequirePermission(Permissions.Port.ConfigureAsAccess)]
    public class ConfigurePortAccessCommandHandler : IRequestHandler<ConfigurePortAccessCommand>
    {
        private readonly ISwitchManagmentDbContext _dbContext;
        private readonly ISwitchHandlerProvider _switchHandlerProvider;
        private readonly ICurrentUserService _curentUserService;
        private readonly IMapper _mapper;

        public ConfigurePortAccessCommandHandler(ISwitchManagmentDbContext dbContext, ISwitchHandlerProvider switchHandlerProvider, ICurrentUserService curentUserService, IMapper mapper) 
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _switchHandlerProvider = switchHandlerProvider ?? throw new ArgumentNullException(nameof(switchHandlerProvider));
            _curentUserService = curentUserService ?? throw new ArgumentNullException(nameof(curentUserService));
            _mapper = _mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Handle(ConfigurePortAccessCommand request, CancellationToken cancellationToken)
        {
            var @switch = await _dbContext.Switches.FindAsync([request.SwitchId], cancellationToken) ??
                throw new NotFoundAppException("Switch not found.");

            bool aclBypass = _curentUserService.HasPermission(Permissions.Port.AclBypass);

            bool canConfigurePortAsAccess = aclBypass || _dbContext.PortsACL.Any(portAce => portAce.SwitchId == @switch.Id && portAce.InterfaceName == request.InterfaceName && portAce.RightsMask.HasFlag(PortRights.ConfigureAsAccess));

            bool canSetVlanAsAccess = aclBypass || _dbContext.VlansACL.Any(vlanAce => vlanAce.SwitchId == @switch.Id && vlanAce.VlanId == request.AccessVlan && vlanAce.RightsMask.HasFlag(VlanRigths.ConfigureAsAccess));

            bool canConfigure = canConfigurePortAsAccess && canSetVlanAsAccess;

            if (canConfigure)
                throw new AccessDeniedAppException("Access denied.");

            var handler = _switchHandlerProvider.GetHandler(@switch.Handler);

            var config = request.Adapt(_mapper.Map<SwitchEntity, PortAccessConfig>(@switch));

            await handler.ConfigurePort(config, cancellationToken);
        }
    }
}
