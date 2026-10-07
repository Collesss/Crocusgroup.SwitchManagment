using Application.DbContext;
using Infrastructure.Persistence.Interfaces;
using Infrastructure.Persistence.SQLite.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SwitchManagmentDbContext>(opts =>
                opts.UseSqlite(connectionString));

            services.AddScoped<ISwitchManagmentDbContext>(provider => provider.GetRequiredService<SwitchManagmentDbContext>());

            services.AddScoped<IDbContextErrorTranslator, DbContextErrorTranslatorSQLite>();

            return services;
        }
    }
}
