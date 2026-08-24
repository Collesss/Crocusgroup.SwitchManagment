using Application.Common.Exceptions;
using Application.Repository.Exceptions;
using Application.Repository.Interfaces;
using Application.Repository.Models;
using MapsterMapper;
using MediatR;

namespace Application.Switches.Commands.Add
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
                return await _switchRepository.AddAsync(_mapper.Map<AdminAddSwitchCommand, SwitchDto>(request), cancellationToken);
            }
            catch(ConfilictRepositoryException e)
            {
                throw new ConflictAppException("Switch with this value field \"IpOrName\" already exists.", e);
            }
            catch(Exception e)
            {
                throw new AppException("Unknow error, see innerException", e);
            }
        }
    }
}
