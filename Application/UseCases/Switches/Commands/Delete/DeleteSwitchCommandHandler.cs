using Application.Repository.Interfaces;
using MediatR;

namespace Application.UseCases.Switches.Commands.Delete
{
    public class DeleteSwitchCommandHandler : IRequestHandler<DeleteSwitchCommand>
    {
        private readonly ISwitchRepository _switchRepository;

        public DeleteSwitchCommandHandler(ISwitchRepository switchRepository)
        {
            _switchRepository = switchRepository ?? throw new ArgumentNullException(nameof(switchRepository));
        }

        public async Task Handle(DeleteSwitchCommand request, CancellationToken cancellationToken) =>
            await _switchRepository.DeleteAsync(request.Id, cancellationToken);
    }
}
