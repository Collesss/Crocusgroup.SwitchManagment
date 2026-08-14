using Application.Repository.Interfaces;
using Application.Repository.Models;
using MapsterMapper;
using MediatR;

namespace Application.UseCases.Switches.Queries.GetSwitchDetail
{
    public class GetSwitchDetailHandler : IRequestHandler<GetSwitchDetailQuery, GetSwitchDetailVm>
    {
        private readonly ISwitchRepository _switchRepository;
        private readonly IMapper _mapper;

        public GetSwitchDetailHandler(ISwitchRepository switchRepository, IMapper mapper)
        {
            _switchRepository = switchRepository ?? throw new ArgumentNullException(nameof(switchRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetSwitchDetailVm> Handle(GetSwitchDetailQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<SwitchDto, GetSwitchDetailVm>(await _switchRepository.GetById(request.Id, cancellationToken));
    }
}
