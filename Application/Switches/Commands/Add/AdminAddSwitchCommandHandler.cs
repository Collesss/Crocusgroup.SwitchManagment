using Application.Common.Exceptions;
using Application.CurrentUserService.Interfaces;
using Application.DbContext;
using Application.DbContext.Models;
using MapsterMapper;
using MediatR;

namespace Application.Switches.Commands.Add
{
    public class AdminAddSwitchCommandHandler : IRequestHandler<AdminAddSwitchCommand, int>
    {
        private readonly ISwitchManagmentDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public AdminAddSwitchCommandHandler(ISwitchManagmentDbContext dbContext, IMapper mapper, ICurrentUserService currentUserService) 
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
        }

        public async Task<int> Handle(AdminAddSwitchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_currentUserService.IsAdmin)
                    throw new AccessDeniedAppException("Add switches can only admins.");

                var trak = await _dbContext.Switches.AddAsync(_mapper.Map<AdminAddSwitchCommand, SwitchEntity>(request), cancellationToken);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return trak.Entity.Id;
            }
            catch(OperationCanceledException)
            {
                throw;
            }
            catch(AppException)
            {
                throw;
            }
            catch(Exception e)
            {
                throw new AppException("An unknown error occurred while adding the switch, see innerException.", e);
            }
        }
    }
}
