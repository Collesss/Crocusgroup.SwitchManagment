using Infrastructure.Persistence.SQLite;
using Infrastructure.Persistence.SQLite.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.UnitTests.UseCases.Common
{
    public static class DbContextFactory
    {

        public static SQLiteDbContext Create()
        {
            var opts = new DbContextOptionsBuilder<SQLiteDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            
            var context = new SQLiteDbContext(opts);

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

            return context;
        }

        public static void Destroy(SQLiteDbContext dbContext)
        {
            dbContext.Dispose();
        }
    }
}
