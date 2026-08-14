using Infrastructure.Persistence.SQLite.Models;
using Infrastructure.Persistence.SQLite.ModelsConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.SQLite
{
    public class SQLiteDbContext : DbContext
    {
        public DbSet<SwitchDbEntity> Switches { get; set; }

        public SQLiteDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SwitchDbEntityConfiguration());
        }
    }
}
