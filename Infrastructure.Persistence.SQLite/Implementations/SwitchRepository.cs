using Application.Repository.Exceptions;
using Application.Repository.Interfaces;
using Application.Repository.Models;
using Infrastructure.Persistence.SQLite.Models;
using MapsterMapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
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

        public async Task<SwitchDto> GetById(int id, CancellationToken cancellationToken = default)
        {
            #region validation
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Param \"id\" cannot be less than 1.");
            #endregion

            try
            {
                return _mapper.Map<SwitchDbEntity, SwitchDto>(await _dbContext.Switches.FindAsync([id], cancellationToken) ?? 
                    throw new NotFoundRepositoryException("Switch with this id not found."));
            }
            catch (NotFoundRepositoryException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new RepositoryException("Unknow error, see innerException.", e);
            }
        }

        public async Task<SwitchesListDto> Get(GetSwitchesListDto getDto, CancellationToken cancellationToken = default)
        {
            #region validation
            ArgumentNullException.ThrowIfNull(getDto);

            if (getDto.PageSize < 1 || getDto.PageSize > 100)
                throw new ArgumentOutOfRangeException(nameof(getDto.PageSize), getDto.PageSize, "Page size must be between 1 and 100 inclusive.");
            
            if (getDto.PageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(getDto.PageNumber), getDto.PageNumber, "The page number must be greater than 0.");

            {
                var searchProps = getDto.GetType().GetProperties()
                    .Where(prop => prop.PropertyType.Name == "System.String"/* && prop.PropertyType.Name.StartsWith("SearchBy")*/);

                foreach (var prop in searchProps)
                {
                    string propValue = prop.GetValue(getDto).ToString();

                    if (propValue.Length > 100)
                        throw new ArgumentOutOfRangeException($"{prop.Name}.Length", propValue.Length, $"The length of the string parameter \"{prop.Name}\" cannot be greater than 100.");
                }
            }
            #endregion

            (string filter, object[] args) GetFilterAndArgs()
            {
                var notNullAndEmptySearchProps = getDto.GetType().GetProperties()
                    .Where(prop => prop.Name.StartsWith("SearchBy") && prop.GetValue(getDto) is string str && !string.IsNullOrEmpty(str));

                string filter = string.Join(" AND ", notNullAndEmptySearchProps
                    .Select((prop, i) => $"{prop.Name.Replace("SearchBy", string.Empty)}.Contains(@{i})"));

                object[] args = notNullAndEmptySearchProps.Select(prop => prop.GetValue(getDto)).ToArray();

                return (filter, args);
            }
            
            /*
            var filter = getDto.GetType().GetProperties()
                .Where(prop => prop.Name.StartsWith("SearchBy") && prop.GetValue(getDto) is string str && !string.IsNullOrEmpty(str))
                .Aggregate(PredicateBuilder.New<SwitchDbEntity>(true), (seed, prop) => 
                    seed.And(dbEnt => EF.Functions.Like($"{prop.Name.Replace("SearchBy", string.Empty)}", prop.GetValue(getDto).ToString())));
            */
            
            try
            {
                (string filter, object[] args) = GetFilterAndArgs();

                int totalCount = _dbContext.Switches.Count(filter, args);

                int maxPages = (totalCount / getDto.PageSize) + ((totalCount % getDto.PageSize) > 0 ? 1 : 0);

                int actualPageNumber = Math.Min(getDto.PageNumber, maxPages);

                var result = _mapper.Map<GetSwitchesListDto, SwitchesListDto>(getDto);
                result.PageNumber = actualPageNumber;
                result.TotalCount = totalCount;
                result.Switches = _mapper.Map<IEnumerable<SwitchDbEntity>, IEnumerable<SwitchLookupDto>>(await _dbContext.Switches
                    .Where(filter, args)
                    .OrderBy($"{getDto.SortField} {(getDto.SortAsc ? "ascending" : "descending")}")
                    .Skip((actualPageNumber - 1) * getDto.PageSize)
                    .Take(getDto.PageSize)
                    .ToListAsync(cancellationToken));
                /*
                //Not used because if the page number is greater than the last page number, an empty list of entities will be returned.
                var test = _dbContext.Switches
                    .Where(filter, args)
                    .OrderBy($"{getDto.SortField} {(getDto.SortAsc ? "ascending" : "descending")}")
                    .PageResult(getDto.PageNumber, getDto.PageSize);
                */

                return result;
            }
            catch(Exception e)
            {
                throw new RepositoryException("Unknow error, see innerException.", e);
            }
        }

        public async Task<int> AddAsync(SwitchDto switchAddDto, CancellationToken cancellationToken = default)
        {
            #region validation
            ArgumentNullException.ThrowIfNull(switchAddDto);
            ArgumentNullException.ThrowIfNull(switchAddDto.IpOrName);

            {
                var stringProps = switchAddDto.GetType().GetProperties()
                    .Where(prop => prop.PropertyType.Name == "System.String");

                foreach (var prop in stringProps)
                {
                    string propValue = prop.GetValue(switchAddDto)?.ToString();

                    if (propValue is not null && propValue.Length > 100)
                        throw new ArgumentOutOfRangeException(prop.Name, propValue, $"The length of the string parameter \"{prop.Name}\" cannot be greater than 100.");
                }
            }
            #endregion

            try
            {
                SwitchDbEntity switchEntity = _mapper.Map<SwitchDto, SwitchDbEntity>(switchAddDto);

                var addEntryEntity = _dbContext.Switches.Add(switchEntity);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return addEntryEntity.Entity.Id;
            }
            catch(DbUpdateException e) when (e.InnerException is SqliteException sqliteException && sqliteException.SqliteErrorCode == 19)
            {
                throw new ConfilictRepositoryException("Switch with this value field \"IpOrName\" already exists.", e);
            }
            catch (Exception e)
            {
                throw new RepositoryException("Unknow error, see innerException.", e);
            }
        }

        public async Task UpdateAsync(SwitchDto switchUpdateDto, CancellationToken cancellationToken = default)
        {
            #region validation
            ArgumentNullException.ThrowIfNull(switchUpdateDto);

            if (switchUpdateDto.Id < 1)
                throw new ArgumentOutOfRangeException(nameof(switchUpdateDto.Id), switchUpdateDto.Id, "Param \"switchUpdateDto.Id\" cannot be less than 1.");

            if (switchUpdateDto.Id < 1)


            {
                var stringProps = switchUpdateDto.GetType().GetProperties()
                    .Where(prop => prop.PropertyType.Name == "System.String");

                foreach (var prop in stringProps)
                {
                    string propValue = prop.GetValue(switchUpdateDto)?.ToString();

                    if (propValue is not null && propValue.Length > 100)
                        throw new ArgumentOutOfRangeException(prop.Name, propValue, $"The length of the string parameter \"{prop.Name}\" cannot be greater than 100.");
                }
            }
            #endregion

            try
            {
                var updateSwitch = _mapper.Map<SwitchDto, SwitchDbEntity>(switchUpdateDto);

                _dbContext.Update(updateSwitch);

                await _dbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new ConfilictRepositoryException("Switch with this value field \"IpOrName\" already exists.", e);
            }
            catch (Exception e)
            {
                throw new RepositoryException("Unknow error, see innerException.", e);
            }
        }
        
        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            #region validation
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Param \"id\" cannot be less than 1.");
            #endregion

            try
            {
                _dbContext.Switches.Remove(new SwitchDbEntity { Id = id });

                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new NotFoundRepositoryException("Switch with this id not found.", e);
            }
            catch(Exception e)
            {
                throw new RepositoryException("Unknow error, see innerException.", e);
            }
        }
    }
}
