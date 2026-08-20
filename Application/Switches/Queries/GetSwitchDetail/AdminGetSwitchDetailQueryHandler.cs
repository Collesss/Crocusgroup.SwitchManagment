using Application.Common.Exceptions;
using Application.Repository.Exceptions;
using Application.Repository.Exceptions.Enums;
using Application.Repository.Interfaces;
using Application.Repository.Models;
using MapsterMapper;
using MediatR;

namespace Application.Switches.Queries.GetSwitchDetail
{
    public class AdminGetSwitchDetailQueryHandler : IRequestHandler<AdminGetSwitchDetailQuery, AdminSwitchDetailVm>
    {
        private readonly ISwitchRepository _switchRepository;
        private readonly IMapper _mapper;

        public AdminGetSwitchDetailQueryHandler(ISwitchRepository switchRepository, IMapper mapper)
        {
            _switchRepository = switchRepository ?? throw new ArgumentNullException(nameof(switchRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AdminSwitchDetailVm> Handle(AdminGetSwitchDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _mapper.Map<SwitchDto, AdminSwitchDetailVm>(await _switchRepository.GetById(request.Id, cancellationToken));
            }
            catch(RepositoryException e) when (e.BaseErrorCode == RepositoryErrorCode.SwitchGetByIdNotFound)
            {
                throw new AppException(Common.Exceptions.Enums.AppErrorCode.AdminGetSwitchDetailNotFound);
            }
        }
    }
}
