using Application.Common.Interfaces;
using Application.DbContext;
using Application.DbContext.Models;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Application.Common.Query.List
{
    public abstract class CommonListQueryHandler<TQuery, TResponse, TResponseLookupDto, TFilter, TContextEntity> : IRequestHandler<TQuery, TResponse>
        where TQuery : CommonListQuery<TFilter>, IRequest<TResponse>
        where TResponse : CommonListResponse<TResponseLookupDto, TFilter>
        where TResponseLookupDto : class
        where TFilter : class, new()
        where TContextEntity : BaseEntity
    {
        private readonly ISwitchManagmentDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IFilterApplier<TFilter, TContextEntity> _filterApplier;

        protected virtual string DefaultSortField { get => "Id"; }

        protected virtual Dictionary<string, string> TranslateFields { get => []; }

        public CommonListQueryHandler(ISwitchManagmentDbContext dbContext, IMapper mapper, IFilterApplier<TFilter, TContextEntity> filterApplier)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _filterApplier = filterApplier ?? throw new ArgumentNullException(nameof(filterApplier));
        }

        protected string GetActualSortField(string field) =>
            string.IsNullOrWhiteSpace(field) ? DefaultSortField : field;

        protected string TranslateSortField(string field) =>
            string.IsNullOrWhiteSpace(field) ? DefaultSortField : (TranslateFields.TryGetValue(field, out string translatedField) ? translatedField : field);

        public async Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var query = _filterApplier.ApplyFilter(request.Filter, _dbContext.Set<TContextEntity>());

            int totalCount = query.Count();

            int maxPage = totalCount / request.PageSize + (totalCount % request.PageSize > 0 ? 1 : 0);

            int actualPageNumber = Math.Min(request.PageNumber, maxPage);

            string actualSortField = GetActualSortField(request.SortField);

            query = query.OrderBy($"{TranslateSortField(request.SortField)} {(request.SortAsc ? "ascending" : "descending")}")
                .Skip((actualPageNumber - 1) * request.PageSize)
                .Take(request.PageSize);

            var result = _mapper.Map<TQuery, TResponse>(request);
            result.Entities = await query.ProjectToType<TResponseLookupDto>().ToListAsync(cancellationToken); //_mapper.Map<IEnumerable<TContextEntity>, IEnumerable<TResponseLookupDto>>(await query.ToListAsync(cancellationToken));
            result.TotalCount = totalCount;
            result.PageNumber = actualPageNumber;
            result.SortField = actualSortField;

            return result;
        }
    }
}
