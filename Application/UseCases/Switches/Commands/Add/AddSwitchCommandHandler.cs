using Application.Repository.Interfaces;
using Application.Repository.Models;
using MapsterMapper;
using MediatR;

namespace Application.UseCases.Switches.Commands.Add
{
    public class AddSwitchCommandHandler : IRequestHandler<AddSwitchCommand, int>
    {
        private readonly ISwitchRepository _switchRepository;
        private readonly IMapper _mapper;

        public AddSwitchCommandHandler(ISwitchRepository switchRepository, IMapper mapper) 
        {
            _switchRepository = switchRepository ?? throw new ArgumentNullException(nameof(switchRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> Handle(AddSwitchCommand request, CancellationToken cancellationToken) => 
            await _switchRepository.AddAsync(_mapper.Map<AddSwitchCommand, SwitchAddDto>(request), cancellationToken);
    }
}
