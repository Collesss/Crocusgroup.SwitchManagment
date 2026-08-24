using Application.Repository.Interfaces;
using Application.Repository.Models;
using Application.SwitchHandling.Handler.Models;
using Application.SwitchHandling.Provider.Interfaces;
using Mapster;
using MapsterMapper;
using MediatR;

namespace Application.Ports.Commands.Access
{
    public class ConfigurePortAccessCommandHandler : IRequestHandler<ConfigurePortAccessCommand>
    {
        private readonly ISwitchRepository _switchRepository;
        private readonly ISwitchHandlerProvider _switchHandlerProvider;
        private readonly IMapper _mapper;

        public ConfigurePortAccessCommandHandler(ISwitchRepository switchRepository, ISwitchHandlerProvider switchHandlerProvider, IMapper mapper) 
        {
            _switchRepository = switchRepository ?? throw new ArgumentNullException(nameof(switchRepository));
            _switchHandlerProvider = switchHandlerProvider ?? throw new ArgumentNullException(nameof(switchHandlerProvider));
            _mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        public async Task Handle(ConfigurePortAccessCommand request, CancellationToken cancellationToken)
        {
            var @switch = await _switchRepository.GetById(request.SwitchId, cancellationToken);

            var handler = _switchHandlerProvider.GetHandler(@switch.Handler);

            var config = request.Adapt(_mapper.Map<SwitchDto, PortAccessConfig>(@switch));

            await handler.ConfigurePort(config, cancellationToken);
        }
    }
}
