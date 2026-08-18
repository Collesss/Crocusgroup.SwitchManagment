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

        public Task<SwitchesListDto> Get(GetSwitchesListDto getDto, CancellationToken cancellationToken = default)
        {
            var filter = getDto.GetType().GetProperties()
                .Where(prop => prop.Name.StartsWith("SearchBy") && prop.GetValue(getDto) is not null)
                .Aggregate(PredicateBuilder.New<SwitchDbEntity>(true), (seed, prop) => seed.And(dbEnt => EF.Functions.Like($"{prop.Name}", prop.GetValue(getDto).ToString())));



            throw new NotImplementedException();
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
