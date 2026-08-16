using Application.Common.Exceptions;
using Application.Common.Exceptions.Enums;
using Application.Repository.Exceptions;
using Application.Repository.Exceptions.Enums;
using Application.Repository.Interfaces;
using Application.Repository.Models;
using MapsterMapper;
using MediatR;

namespace Application.UseCases.Switches.Commands.Add
{
    public class AdminAddSwitchCommandHandler : IRequestHandler<AdminAddSwitchCommand, int>
    {
        private readonly ISwitchRepository _switchRepository;
        private readonly IMapper _mapper;

        public AdminAddSwitchCommandHandler(ISwitchRepository switchRepository, IMapper mapper) 
        {
            _switchRepository = switchRepository ?? throw new ArgumentNullException(nameof(switchRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> Handle(AdminAddSwitchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _switchRepository.AddAsync(_mapper.Map<AdminAddSwitchCommand, SwitchAddDto>(request), cancellationToken);
            }
            catch(RepositoryException e) when (e.ErrorCode == RepositoryErrorCode.SwitchAddIpAlreadyExist)
            {
                throw new ApplicationLayerException(ApplicationErrorCode.AdminAddSwitchAlreadyExist);
            }
        }
    }
}
