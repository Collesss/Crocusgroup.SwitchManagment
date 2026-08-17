using Application.Repository.Interfaces;
using MapsterMapper;
using MediatR;

namespace Application.Switches.Queries.GetSwitchesList
{
    public class AdminGetSwitchesListQueryHandler : IRequestHandler<AdminGetSwitchesListQuery, AdminSwitchesListVm>
    {
        private readonly ISwitchRepository _switchRepository;
        private readonly IMapper _mapper;

        public AdminGetSwitchesListQueryHandler(ISwitchRepository switchRepository, IMapper mapper)
        {
            _switchRepository = switchRepository ?? throw new ArgumentNullException(nameof(switchRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<AdminSwitchesListVm> Handle(AdminGetSwitchesListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
