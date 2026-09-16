using Application.Common.Exceptions;
using Application.DbContext;
using Application.DbContext.Models;
using MapsterMapper;
using MediatR;

namespace Application.Switches.Commands.Delete
{
    public class AdminDeleteSwitchCommandHandler : IRequestHandler<AdminDeleteSwitchCommand>
    {
        private readonly ISwitchManagmentDbContext _dbContext;
        private readonly IMapper _mapper;

        public AdminDeleteSwitchCommandHandler(ISwitchManagmentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Handle(AdminDeleteSwitchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _dbContext.Switches.Remove(_mapper.Map<AdminDeleteSwitchCommand, SwitchEntity>(request));

                await _dbContext.SaveChangesAsync(cancellationToken);
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
                throw new AppException("An unknown error occurred while deleting the switch, see innerException.", e);
            }
        }
    }
}
