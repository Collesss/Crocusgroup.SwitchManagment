using Application.Common.Exceptions;
using Application.DbContext;
using Application.DbContext.Exceptions;
using Application.DbContext.Models;
using Application.DbContext.Models.ACE.Port;
using Application.DbContext.Models.ACE.Switch;
using Application.DbContext.Models.ACE.Vlan;
using Application.DbContext.Models.ACE.VlanOnPort;
using Infrastructure.Persistence.Interfaces;
using Infrastructure.Persistence.ModelsConfigurations;
using Infrastructure.Persistence.ModelsConfigurations.ACE;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class SwitchManagmentDbContext : DbContext, ISwitchManagmentDbContext
    {
        public DbSet<SwitchEntity> Switches { get; set; }

        public DbSet<SwitchAceEntity> SwitchesACL { get; set; }

        public DbSet<PortAceEntity> PortsACL { get; set; }

        public DbSet<VlanAceEntity> VlansACL { get; set; }

        public DbSet<VlanOnPortAceEntity> VlanOnPortACL { get; set; }

        private readonly IDbContextErrorTranslator _errorTranslator;

        public SwitchManagmentDbContext(DbContextOptions<SwitchManagmentDbContext> options, IDbContextErrorTranslator errorTranslator) : base(options)
        {
            _errorTranslator = errorTranslator ?? throw new ArgumentNullException(nameof(errorTranslator));
            
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

            modelBuilder.ApplyConfiguration(new SwitchAceDbEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PortAceDbEntityConfiguration());
            modelBuilder.ApplyConfiguration(new VlanAceDbEntityConfiguration());
            modelBuilder.ApplyConfiguration(new VlanOnPortAceDbEntityConfiguration());
        }

        DbSet<TEntity> ISwitchManagmentDbContext.Set<TEntity>() =>
            base.Set<TEntity>();

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                try
                {
                    throw _errorTranslator.Translate(e);
                }
                catch(AppException)
                {
                    throw;
                }
                catch (Exception e2)
                {
                    throw new DbContextException("An unknown error occurred while save changes, see innerException.", e2);
                }
            }
        }
    }
}