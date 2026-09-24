using Application.Common.Exceptions;
using Application.CurrentUserService.Interfaces;
using Application.CurrentUserService.Security;
using Application.DbContext;
using Application.DbContext.Models;
using Application.SwitchHandling.Handler.Models;
using Application.SwitchHandling.Provider.Interfaces;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Switches.Queries.GetSwitchDetail
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

            var response = _mapper.Map<SwitchEntity, SwitchDetailResponse>(@switch);

            var handler = _switchHandlerProvider.GetHandler(@switch.Handler);

            var switchInfo = await handler.GetSwitchInfo(_mapper.Map<SwitchEntity, ConnectConfig>(@switch), cancellationToken);

            response = switchInfo.Adapt(response);


            return response;
        }
    }
}