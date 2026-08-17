using Application.Common.Exceptions;
using Application.Common.Exceptions.Enums;
using Application.Repository.Exceptions;
using Application.Repository.Exceptions.Enums;
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
            catch (RepositoryException e) when (e.BaseErrorCode == RepositoryErrorCode.SwitchDeleteNotFound)
            {
                throw new ApplicationLayerException(ApplicationErrorCode.AdminDeleteSwitchNotFound);
            }
        }
    }
}
