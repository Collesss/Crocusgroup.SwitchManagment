using Application.DbContext;
using MapsterMapper;
using MediatR;
using Application.Common.Exceptions;
using Application.CurrentUserService.Security;

namespace Application.Switches.Queries.GetSwitchDetail
{
    [RequirePermission(Permissions.Switch.View)]
    public class GetSwitchDetailQueryHandler : IRequestHandler<GetSwitchDetailQuery, SwitchDetailVm>
    {
        private readonly ISwitchManagmentDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSwitchDetailQueryHandler(ISwitchManagmentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SwitchDetailVm> Handle(GetSwitchDetailQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<SwitchDetailVm>(await _dbContext.Switches.FindAsync([request.Id], cancellationToken: cancellationToken) ?? 
                throw new NotFoundAppException("Switch with this Id not found."));
    }
}
