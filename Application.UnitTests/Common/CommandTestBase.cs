using Infrastructure.Persistence.SQLite;
using Mapster;
using MapsterMapper;
using System.Reflection;

namespace Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly SQLiteDbContext _dbContext;
        protected readonly IMapper _mapper;

        public CommandTestBase()
        {
            _dbContext = DbContextFactory.Create();

            var config = new TypeAdapterConfig();
            config.Scan([Assembly.Load("Application"), Assembly.Load("Application.Repository")]);

            _mapper = new Mapper(config);
        }

        public void Dispose()
        {
            DbContextFactory.Destroy(_dbContext);
        }
    }
}
