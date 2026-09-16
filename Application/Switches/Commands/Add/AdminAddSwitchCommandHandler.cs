using Application.Common.Exceptions;
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

        public AdminAddSwitchCommandHandler(ISwitchManagmentDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> Handle(AdminAddSwitchCommand request, CancellationToken cancellationToken)
        {
            try
            {
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
