using Application.Common.Exceptions;
using Application.DbContext;
using Application.DbContext.Models;
using MapsterMapper;
using MediatR;

namespace Application.Common.Query.Detail
{
    public abstract class CommonDetailQueryHandler<TRequest, TResponse, TEntity>(ISwitchManagmentDbContext dbContext, IMapper mapper) : IRequestHandler<TRequest, TResponse>
        where TRequest : CommonDetailQuery, IRequest<TResponse>
        where TEntity : BaseEntity
    {
        private readonly ISwitchManagmentDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken) =>
            _mapper.Map<TEntity, TResponse>(await _dbContext.Set<TEntity>().FindAsync([request.Id], cancellationToken: cancellationToken) ??
                throw new NotFoundAppException("Entity with this Id not found."));
    }
}
