using Application.DbContext;
using Application.DbContext.Models;
using MapsterMapper;
using MediatR;

namespace Application.Switches.Queries.GetSwitchesList
{
    public class GetSwitchesListQueryHandler : IRequestHandler<GetSwitchesListQuery, SwitchesListResponse>
    {
        private readonly ISwitchManagmentDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSwitchesListQueryHandler(ISwitchManagmentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SwitchesListResponse> Handle(GetSwitchesListQuery request, CancellationToken cancellationToken)
        {




            return _mapper.Map<SwitchEntity, SwitchesListResponse>(await _switchRepository.Get(_mapper.Map<GetSwitchesListQuery, GetSwitchesListDto>(request), cancellationToken));
        }
    }
}
