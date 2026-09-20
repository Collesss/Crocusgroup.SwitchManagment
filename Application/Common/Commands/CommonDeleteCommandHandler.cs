using Application.DbContext;
using Application.DbContext.Models;
using MapsterMapper;
using MediatR;

namespace Application.Common.Commands
{
    public abstract class CommonDeleteCommandHandler<TCommand, TEntity> : IRequestHandler<TCommand>
        where TCommand : IRequest
        where TEntity : BaseEntity
    {
        protected readonly ISwitchManagmentDbContext _dbContext;
        protected readonly IMapper _mapper;

        public CommonDeleteCommandHandler(ISwitchManagmentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public virtual async Task Handle(TCommand request, CancellationToken cancellationToken)
        {
            _dbContext.Set<TEntity>().Remove(_mapper.Map<TCommand, TEntity>(request));

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

    }
}