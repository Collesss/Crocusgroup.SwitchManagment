using Application.Common.Exceptions;
using Application.CurrentUserService.Interfaces;
using Application.CurrentUserService.Security;
using Application.DbContext;
using Application.DbContext.Models;
using Application.DbContext.Models.ACE.Port;
using Application.DbContext.Models.ACE.Switch;
using Application.DbContext.Models.ACE.Vlan;
using Application.Switches.Queries.GetSwitchDetail.Response;
using Application.Switches.Queries.GetSwitchDetail.Response.Port;
using Application.SwitchHandling.Handler.Models;
using Application.SwitchHandling.Provider.Interfaces;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Switches.Queries.GetSwitchDetail.Query
{
    [RequirePermission(Permissions.Switch.View)]
    public class GetSwitchDetailQueryHandler : IRequestHandler<GetSwitchDetailQuery, SwitchDetailResponse>
    {
        private readonly ISwitchManagmentDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ISwitchHandlerProvider _switchHandlerProvider;
        private readonly ICurrentUserService _currentUserService;

        public GetSwitchDetailQueryHandler(ISwitchManagmentDbContext dbContext, IMapper mapper, ISwitchHandlerProvider switchHandlerProvider, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _switchHandlerProvider = switchHandlerProvider ?? throw new ArgumentNullException(nameof(switchHandlerProvider));
            _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
        }

        public async Task<SwitchDetailResponse> Handle(GetSwitchDetailQuery request, CancellationToken cancellationToken)
        {
            //.Include(@switch => @switch.SwitchACL.Where(switchAce => /*switchAce.Id == @switch.Id && */_currentUserService.GroupsIds.Contains(switchAce.GroupId)))

            var @switch = await _dbContext.Switches
                .FindAsync([request.Id], cancellationToken: cancellationToken) ?? throw new NotFoundAppException("Entity with this Id not found.");

            bool aclBypass = _currentUserService.HasPermission(Permissions.Switch.AclBypass);

            bool hasSwitchAccess = aclBypass ||
                _dbContext.SwitchesACL.Any(switchAce => switchAce.SwitchId == @switch.Id && _currentUserService.GroupsIds.Contains(switchAce.GroupId) &&
                switchAce.RightsMask.HasFlag(SwitchRights.DetailView));

            if (!hasSwitchAccess)
                throw new AccessDeniedAppException("Access denied.");

            var response = _mapper.Map<SwitchEntity, SwitchDetailResponse>(@switch);

            var handler = _switchHandlerProvider.GetHandler(@switch.Handler);

            var switchInfo = await handler.GetSwitchInfo(_mapper.Map<SwitchEntity, ConnectConfig>(@switch), cancellationToken);

            response = switchInfo.Adapt(response);

            if(aclBypass)
                return response;

            var portAcl = await _dbContext.PortsACL.Where(portAce => portAce.SwitchId == @switch.Id && _currentUserService.GroupsIds.Contains(portAce.GroupId))
                .AggregateBy(portAce => portAce.InterfaceName, PortRights.None, (rights, portAce) => rights & portAce.RightsMask)
                .ToListAsync(cancellationToken);

            var vlanAcl = await _dbContext.VlansACL.Where(vlanAce => vlanAce.SwitchId == @switch.Id && _currentUserService.GroupsIds.Contains(vlanAce.GroupId))
                .AggregateBy(vlanAce => vlanAce.VlanId, VlanRigths.None, (rigths, vlanAce) => rigths & vlanAce.RightsMask)
                .ToListAsync(cancellationToken);

            
            response.Vlans = vlanAcl.Join(switchInfo.Vlans, vlanAce => vlanAce.Key, vlanOnSwitch => vlanOnSwitch.Vlan, (vlanAce, vlanOnSwitch) => vlanOnSwitch.Adapt(_mapper.Map<VlanDto>(vlanAce)))
                .ToArray();

            response.Ports = portAcl.Join(switchInfo.Ports, portAce => portAce.Key, portOnSwitch => portOnSwitch.Interface, (portAce, portOnSwitch) => portOnSwitch.Adapt(_mapper.Map<PortDto>(portAce)))
                .ToArray();

            return response;
        }
    }
}