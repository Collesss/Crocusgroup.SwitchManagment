using Application.Common.Interfaces;
using Application.DbContext;
using Application.DbContext.Models;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Application.Common.Query
{
    public class CommonListQueryHandler<TQuery, TResponse, TResponseLookupDto, TSortField, TFilter, TContextEntity> : IRequestHandler<TQuery, TResponse>
        where TQuery : CommonListQuery<TFilter, TSortField>, IRequest<TResponse>
        where TResponse : CommonListResponse<TResponseLookupDto, TFilter, TSortField>
        where TResponseLookupDto : class
        where TFilter : class, new()
        where TSortField : Enum
        where TContextEntity : BaseEntity
    {
        private readonly ISwitchManagmentDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IFilterApplier<TFilter, TContextEntity> _filterApplier;

        public CommonListQueryHandler(ISwitchManagmentDbContext dbContext, IMapper mapper, IFilterApplier<TFilter, TContextEntity> filterApplier)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _filterApplier = filterApplier ?? throw new ArgumentNullException(nameof(filterApplier));
        }

        public async Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var query = _filterApplier.ApplyFilter(request.Filter, _dbContext.Set<TContextEntity>());

            int totalCount = query.Count();

            int maxPage = (totalCount / request.PageSize) + ((totalCount % request.PageSize) > 0 ? 1 : 0);

            int actualPageNumber = Math.Min(request.PageNumber, maxPage);

            query = query.OrderBy($"{request.SortField} {(request.SortAsc ? "ascending" : "descending")}")
                .Skip((actualPageNumber - 1) * request.PageSize)
                .Take(request.PageSize);

            var result = _mapper.Map<TQuery, TResponse>(request);
            result.Entities = _mapper.Map<IEnumerable<TContextEntity>, IEnumerable<TResponseLookupDto>>(await query.ToListAsync(cancellationToken));
            result.TotalCount = totalCount;
            result.PageNumber = actualPageNumber;

            return result;
        }
    }
}
