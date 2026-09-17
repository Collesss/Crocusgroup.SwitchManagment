using Application.Common.Exceptions;
using Application.CurrentUserService.Interfaces;
using Application.DbContext;
using Application.DbContext.Models.ACE.Switch;
using MapsterMapper;
using MediatR;

namespace Application.ACL.Switches.Commands.Delete
{
    public class AdminDeleteSwitchAceCommand : IRequest
    {
        public int Id { get; set; }
        

        public class Handler : IRequestHandler<AdminDeleteSwitchAceCommand>
        {
            private readonly ISwitchManagmentDbContext _dbContext;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService _currentUserService;

            public Handler(ISwitchManagmentDbContext dbContext, IMapper mapper, ICurrentUserService currentUserService)
            {
                _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
            }

            public async Task Handle(AdminDeleteSwitchAceCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    if (!_currentUserService.IsAdmin)
                        throw new AccessDeniedAppException("Delete switches ACE can only admins.");

                    _dbContext.SwitchesACL.Remove(_mapper.Map<AdminDeleteSwitchAceCommand, SwitchAceEntity>(request));

                    await _dbContext.SaveChangesAsync(cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (AppException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    throw new AppException("An unknown error occurred while deleting the switch ace, see innerException.", e);
                }
            }
        }
    }
}
