using Application.CurrentUserService.Security;
using Application.DbContext;
using Application.DbContext.Models;
using MapsterMapper;
using MediatR;

namespace Application.Switches.Commands.Delete
{
    [RequirePermission(Permissions.Switch.Delete)]
    public class DeleteSwitchCommandHandler : IRequestHandler<DeleteSwitchCommand>
    {
        private readonly ISwitchManagmentDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteSwitchCommandHandler(ISwitchManagmentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Handle(DeleteSwitchCommand request, CancellationToken cancellationToken)
        {
            _dbContext.Switches.Remove(_mapper.Map<DeleteSwitchCommand, SwitchEntity>(request));

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}