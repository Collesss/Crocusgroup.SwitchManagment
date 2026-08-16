using Application.Common.Exceptions;
using Application.Repository.Exceptions;
using Application.Repository.Exceptions.Enums;
using Application.Repository.Interfaces;
using Application.Repository.Models;
using MapsterMapper;
using MediatR;

namespace Application.UseCases.Switches.Queries.GetSwitchDetail
{
    public class AdminGetSwitchDetailHandler : IRequestHandler<AdminGetSwitchDetailQuery, AdminGetSwitchDetailVm>
    {
        private readonly ISwitchRepository _switchRepository;
        private readonly IMapper _mapper;

        public AdminGetSwitchDetailHandler(ISwitchRepository switchRepository, IMapper mapper)
        {
            _switchRepository = switchRepository ?? throw new ArgumentNullException(nameof(switchRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AdminGetSwitchDetailVm> Handle(AdminGetSwitchDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _mapper.Map<SwitchDto, AdminGetSwitchDetailVm>(await _switchRepository.GetById(request.Id, cancellationToken));
            }
            catch(RepositoryException e) when (e.ErrorCode == RepositoryErrorCode.SwitchGetByIdNotFound)
            {
                throw new ApplicationLayerException(Common.Exceptions.Enums.ApplicationErrorCode.AdminGetSwitchDetailNotFound);
            }
        }
    }
}
