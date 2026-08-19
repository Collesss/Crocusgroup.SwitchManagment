using Application.Common.Exceptions;
using Application.Common.Exceptions.Enums;
using Application.Repository.Exceptions;
using Application.Repository.Interfaces;
using Application.Repository.Models;
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

        public async Task<AdminSwitchesListVm> Handle(AdminGetSwitchesListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _mapper.Map<SwitchesListDto, AdminSwitchesListVm>(await _switchRepository.Get(_mapper.Map<AdminGetSwitchesListQuery, GetSwitchesListDto>(request), cancellationToken));
            }
            catch(RepositoryException)
            {
                throw new ApplicationLayerException(ApplicationErrorCode.Unknow);
            }
        }
    }
}
