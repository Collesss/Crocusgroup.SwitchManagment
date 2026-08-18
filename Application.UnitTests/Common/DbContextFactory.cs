using Infrastructure.Persistence.SQLite;
using Infrastructure.Persistence.SQLite.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Application.UnitTests.Common
{
    public static class DbContextFactory
    {
        public static SQLiteDbContext Create()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var opts = new DbContextOptionsBuilder<SQLiteDbContext>()
                .UseSqlite(connection)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                //.UseSqlite("Data Source=:memory:")
                //.UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;


            var context = new SQLiteDbContext(opts);

            context.Switches.AddRange(Enumerable.Range(1, 10).Select(i => new SwitchDbEntity
            {
                Id = i,
                IpOrName = $"Host{i}",
                Description = $"Description{i}",
                Handler = "HPComware5",
                Location = $"TestLocation{i}",
                Login = "admin",
                Password = "1111",
                SuperPassword = "1234"
            }));

            context.SaveChanges();

            context.ChangeTracker.Clear();

            return context;
        }

        public static void Destroy(SQLiteDbContext dbContext)
        {
            dbContext.Dispose();
        }
    }
}
