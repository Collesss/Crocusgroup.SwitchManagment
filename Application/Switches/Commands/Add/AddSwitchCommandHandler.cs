using Application.CurrentUserService.Security;
using Application.DbContext;
using Application.DbContext.Models;
using MapsterMapper;
using MediatR;

namespace Application.Switches.Commands.Add
{
    [RequirePermission(Permissions.Switch.Add)]
    public class AddSwitchCommandHandler : IRequestHandler<AddSwitchCommand, int>
    {
        private readonly ISwitchManagmentDbContext _dbContext;
        private readonly IMapper _mapper;

        public AddSwitchCommandHandler(ISwitchManagmentDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> Handle(AddSwitchCommand request, CancellationToken cancellationToken)
        {
            var trak = await _dbContext.Switches.AddAsync(_mapper.Map<AddSwitchCommand, SwitchEntity>(request), cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return trak.Entity.Id;
        }
    }
}
