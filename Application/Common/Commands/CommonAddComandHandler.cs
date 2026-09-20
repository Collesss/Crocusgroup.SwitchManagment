using Application.DbContext;
using Application.DbContext.Models;
using MapsterMapper;
using MediatR;

namespace Application.Common.Commands
{
    public abstract class CommonAddComandHandler<TCommand, TEntity> : IRequestHandler<TCommand, int>
        where TCommand : IRequest<int>
        where TEntity : BaseEntity
    {
        protected readonly ISwitchManagmentDbContext _dbContext;
        protected readonly IMapper _mapper;

        public CommonAddComandHandler(ISwitchManagmentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public virtual async Task<int> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var trak = await _dbContext.Set<TEntity>().AddAsync(_mapper.Map<TCommand, TEntity>(request), cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return trak.Entity.Id;
        }
    }
}
