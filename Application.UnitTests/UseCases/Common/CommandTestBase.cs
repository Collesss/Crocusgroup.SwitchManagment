using Infrastructure.Persistence.SQLite;

namespace Application.UnitTests.UseCases.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly SQLiteDbContext _dbContext;

        public CommandTestBase()
        {
            _dbContext = DbContextFactory.Create();
        }

        public void Dispose()
        {
            DbContextFactory.Destroy(_dbContext);
        }
    }
}
