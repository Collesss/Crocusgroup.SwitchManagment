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

namespace Application.Ports.Commands.Trunk
{
    [RequirePermission(Permissions.Port.ConfigureAsTrunk)]
    public class ConfigurePortTrunkCommandHandler : IRequestHandler<ConfigurePortTrunkCommand>
    {
        private readonly ISwitchManagmentDbContext _dbContext;
        private readonly ISwitchHandlerProvider _switchHandlerProvider;
        private readonly ICurrentUserService _curentUserService;
        private readonly IMapper _mapper;

        public ConfigurePortTrunkCommandHandler(ISwitchManagmentDbContext dbContext, ISwitchHandlerProvider switchHandlerProvider, ICurrentUserService curentUserService, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _switchHandlerProvider = switchHandlerProvider ?? throw new ArgumentNullException(nameof(switchHandlerProvider));
            _curentUserService = _curentUserService ?? throw new ArgumentNullException(nameof(curentUserService));
            _mapper = _mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Handle(ConfigurePortTrunkCommand request, CancellationToken cancellationToken)
        {
            var @switch = await _dbContext.Switches.FindAsync([request.SwitchId], cancellationToken) ??
                throw new NotFoundAppException("Switch not found.");

            bool aclBypass = _curentUserService.HasPermission(Permissions.Port.AclBypass);

            bool canConfigurePortAsTrunk = aclBypass || 
                _dbContext.PortsACL.Any(portAce => portAce.SwitchId == @switch.Id && portAce.InterfaceName == request.InterfaceName && portAce.RightsMask.HasFlag(PortRights.ConfigureAsTrunk));

            bool canSetVlanAsTrunk = aclBypass || 
                request.TrunkVlans.All(trunkVlan => _dbContext.VlansACL.Any(vlanAce => vlanAce.SwitchId == @switch.Id && vlanAce.VlanId == trunkVlan && vlanAce.RightsMask.HasFlag(VlanRigths.ConfigureAsTrunk)));

            bool canConfigure = canConfigurePortAsTrunk && canSetVlanAsTrunk;

            if (canConfigure)
                throw new AccessDeniedAppException("Access denied.");

            var handler = _switchHandlerProvider.GetHandler(@switch.Handler);

            var config = request.Adapt(_mapper.Map<SwitchEntity, PortTrunkConfig>(@switch));

            await handler.ConfigurePort(config, cancellationToken);
        }
    }
}
