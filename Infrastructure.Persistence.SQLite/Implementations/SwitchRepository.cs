using Application.Repository.Exceptions;
using Application.Repository.Exceptions.Enums;
using Application.Repository.Interfaces;
using Application.Repository.Models;
using Infrastructure.Persistence.SQLite.Models;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

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

        public async Task<int> AddAsync(SwitchAddDto switchAddDto, CancellationToken cancellationToken = default)
        {
            SwitchDbEntity switchEntity = _mapper.Map<SwitchAddDto, SwitchDbEntity>(switchAddDto);

            try
            {
                var addEntryEntity = _dbContext.Switches.Add(switchEntity);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return addEntryEntity.Entity.Id;
            }
            catch(DbUpdateException e)
            {
                throw new RepositoryException(ErrorCode.Unknow, e);
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
                throw new RepositoryException(ErrorCode.SwitchDeleteNotFound, e);
            }
        }

        public async Task<SwitchDto> GetById(int id, CancellationToken cancellationToken = default) =>
            _mapper.Map<SwitchDbEntity, SwitchDto>(await _dbContext.Switches.FindAsync([id], cancellationToken) ?? throw new RepositoryException(ErrorCode.SwitchGetByIdNotFound));
    }
}
