using Application.Common.Exceptions;
using Application.Repository.Interfaces;
using MediatR;

namespace Application.Switches.Commands.Delete
{
    public class AdminDeleteSwitchCommandHandler : IRequestHandler<AdminDeleteSwitchCommand>
    {
        private readonly ISwitchRepository _switchRepository;

        public AdminDeleteSwitchCommandHandler(ISwitchRepository switchRepository)
        {
            _switchRepository = switchRepository ?? throw new ArgumentNullException(nameof(switchRepository));
        }

        public async Task Handle(AdminDeleteSwitchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _switchRepository.DeleteAsync(request.Id, cancellationToken);
            }
            catch(AppException)
            {
                throw;
            }
            catch(Exception e)
            {
                throw new AppException("An unknown error occurred while deleting the switch, see innerException.", e);
            }
        }
    }
}
