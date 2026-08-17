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
            
            using(var context = new SQLiteDbContext(opts))
            {
                context.Switches.Add(new SwitchDbEntity
                {
                    Id = 1,
                    IpOrName = "Host1",
                    Description = "Description1",
                    Handler = "HPComware5",
                    Location = "TestLocation",
                    Login = "admin",
                    Password = "1111",
                    SuperPassword = "1234"
                });

                context.SaveChanges();
            }

            return new SQLiteDbContext(opts);
        }

        public static void Destroy(SQLiteDbContext dbContext)
        {
            dbContext.Dispose();
        }
    }
}
