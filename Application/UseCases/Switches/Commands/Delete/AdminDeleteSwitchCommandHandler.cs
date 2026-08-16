using Application.Repository.Interfaces;
using MediatR;

namespace Application.UseCases.Switches.Commands.Delete
{
    public class AdminDeleteSwitchCommandHandler : IRequestHandler<AdminDeleteSwitchCommand>
    {
        private readonly ISwitchRepository _switchRepository;

        public AdminDeleteSwitchCommandHandler(ISwitchRepository switchRepository)
        {
            _switchRepository = switchRepository ?? throw new ArgumentNullException(nameof(switchRepository));
        }

        public async Task Handle(AdminDeleteSwitchCommand request, CancellationToken cancellationToken) =>
            await _switchRepository.DeleteAsync(request.Id, cancellationToken);
    }
}
