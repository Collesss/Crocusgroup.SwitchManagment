using Application.Repository.Exceptions;
using Application.Repository.Exceptions.Enums;
using Application.Repository.Interfaces;
using Application.Repository.Models;
using Infrastructure.Persistence.SQLite.Models;
using LinqKit;
using MapsterMapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Infrastructure.Persistence.SQLite.Implementations
{
    public class SwitchRepository : ISwitchRepository
    {
        private readonly SQLiteDbContext _dbContext;
        private readonly IMapper _mapper;

        public SwitchRepository(SQLiteDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> AddAsync(AddSwitchDto switchAddDto, CancellationToken cancellationToken = default)
        {
            SwitchDbEntity switchEntity = _mapper.Map<AddSwitchDto, SwitchDbEntity>(switchAddDto);

            try
            {
                var addEntryEntity = _dbContext.Switches.Add(switchEntity);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return addEntryEntity.Entity.Id;
            }
            catch(DbUpdateException e) when (e.InnerException is SqliteException sqliteException && sqliteException.SqliteErrorCode == 19)
            {
                throw new RepositoryException(RepositoryErrorCode.SwitchAddIpAlreadyExist, e);
            }
            catch (Exception e)
            {
                throw new RepositoryException(RepositoryErrorCode.Unknow, e);
            }
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                _dbContext.Switches.Remove(new SwitchDbEntity { Id = id });

                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new RepositoryException(RepositoryErrorCode.SwitchDeleteNotFound, e);
            }
            catch(Exception e)
            {
                throw new RepositoryException(RepositoryErrorCode.Unknow, e);
            }
        }

        public async Task<SwitchesListDto> Get(GetSwitchesListDto getDto, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(getDto);

            if (getDto.PageSize < 1 || getDto.PageSize > 100)
                throw new ArgumentOutOfRangeException(nameof(getDto.PageSize), getDto.PageSize, "Page size must be between 1 and 100 inclusive.");

            if (getDto.PageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(getDto.PageNumber), getDto.PageNumber, "The page number must be greater than 0.");


            /*
            var filter = getDto.GetType().GetProperties()
                .Where(prop => prop.Name.StartsWith("SearchBy") && prop.GetValue(getDto) is string str && !string.IsNullOrEmpty(str))
                .Aggregate(PredicateBuilder.New<SwitchDbEntity>(true), (seed, prop) => 
                    seed.And(dbEnt => EF.Functions.Like($"{prop.Name.Replace("SearchBy", string.Empty)}", prop.GetValue(getDto).ToString())));
            */

            try
            {
                var notNullOrEmptySearchProps = getDto.GetType().GetProperties()
                    .Where(prop => prop.Name.StartsWith("SearchBy") && prop.GetValue(getDto) is string str && !string.IsNullOrEmpty(str));

                string filter = string.Join(" AND ", notNullOrEmptySearchProps
                    .Select((prop, i) => $"{prop.Name.Replace("SearchBy", string.Empty)}.Contains(@{i})"));

                var args = notNullOrEmptySearchProps.Select(prop => prop.GetValue(getDto).ToString());

                int totalCount = _dbContext.Switches.Count(filter, args);

                int maxPages = (totalCount / getDto.PageSize) + ((totalCount % getDto.PageSize) > 0 ? 1 : 0);

                var result = _mapper.Map<GetSwitchesListDto, SwitchesListDto>(getDto);
                result.PageNumber = Math.Min(result.PageNumber, maxPages);
                result.TotalCount = totalCount;
                result.Switches = _mapper.Map<IEnumerable<SwitchDbEntity>, IEnumerable<SwitchLookupDto>>(await _dbContext.Switches
                    .Where(filter, args)
                    .OrderBy($"{getDto.SortField} {(getDto.SortAsc ? "ascending" : "descending")}")
                    .Skip((getDto.PageNumber - 1) * getDto.PageSize)
                    .Take(getDto.PageSize)
                    .ToListAsync(cancellationToken));

                return result;
            }
            catch(Exception e)
            {
                throw new RepositoryException(RepositoryErrorCode.Unknow, e);
            }
        }

        public async Task<IEnumerable<SwitchDto>> GetAll(CancellationToken cancellationToken = default) =>
            _mapper.Map<IEnumerable<SwitchDbEntity>, IEnumerable<SwitchDto>>(await _dbContext.Switches.ToListAsync(cancellationToken));

        public async Task<SwitchDto> GetById(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                return _mapper.Map<SwitchDbEntity, SwitchDto>(await _dbContext.Switches.FindAsync([id], cancellationToken) ?? throw new RepositoryException(RepositoryErrorCode.SwitchGetByIdNotFound));
            }
            catch(RepositoryException)
            {
                throw;
            }
            catch(Exception e)
            {
                throw new RepositoryException(RepositoryErrorCode.Unknow, e);
            }
        }
    }
}
