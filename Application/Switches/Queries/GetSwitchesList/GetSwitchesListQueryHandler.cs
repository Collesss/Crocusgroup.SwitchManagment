using Application.Common.Interfaces;
using Application.Common.Query;
using Application.DbContext;
using Application.DbContext.Models;
using MapsterMapper;

namespace Application.Switches.Queries.GetSwitchesList
{
    public class GetSwitchesListQueryHandler(ISwitchManagmentDbContext dbContext, IMapper mapper, IFilterApplier<SwitchFilter, SwitchEntity> filterApplier) : 
        CommonListQueryHandler<GetSwitchesListQuery, SwitchesListResponse, SwitchLookupDto, SwitchSortField, SwitchFilter, SwitchEntity>(dbContext, mapper, filterApplier)
    {

        /*
        private readonly ISwitchManagmentDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IFilterApplier<SwitchFilter, SwitchEntity> _filterApplier;

        public GetSwitchesListQueryHandler(ISwitchManagmentDbContext dbContext, IMapper mapper, IFilterApplier<SwitchFilter, SwitchEntity> filterApplier)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _filterApplier = filterApplier ?? throw new ArgumentNullException(nameof(filterApplier));
        }

        public async Task<SwitchesListResponse> Handle(GetSwitchesListQuery request, CancellationToken cancellationToken)
        {
            var query = _filterApplier.ApplyFilter(request.Filter, _dbContext.Switches);

            int totalCount = query.Count();

            int maxPage = (totalCount / request.PageSize) + ((totalCount % request.PageSize) > 0 ? 1 : 0);

            int actualPageNumber = Math.Min(request.PageNumber, maxPage);

            query = query.OrderBy($"{request.SortField} {(request.SortAsc ? "ascending" : "descending")}")
                .Skip((actualPageNumber - 1) * request.PageSize)
                .Take(request.PageSize);

            var result = _mapper.Map<GetSwitchesListQuery, SwitchesListResponse>(request);
            result.Entities = _mapper.Map<IEnumerable<SwitchEntity>, IEnumerable<SwitchLookupDto>>(await query.ToListAsync(cancellationToken));
            result.TotalCount = totalCount;
            result.PageNumber = actualPageNumber;

            return result;
        }*/
    }
}