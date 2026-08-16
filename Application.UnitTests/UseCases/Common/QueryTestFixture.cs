using Infrastructure.Persistence.SQLite;
using MapsterMapper;

namespace Application.UnitTests.UseCases.Common
{
    public class QueryTestFixture : IDisposable
    {
        public SQLiteDbContext DbContext { get; private set; }

        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            DbContext = DbContextFactory.Create();

            
        }

        public void Dispose()
        {
            DbContextFactory.Destroy(DbContext);
        }
    }
}
