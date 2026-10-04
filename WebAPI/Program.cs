using Application.Common.Behaviors;
using Application.Common.Interfaces;
using Application.CurrentUserService.Interfaces;
using Application.DbContext;
using Application.SwitchHandling.Handler.Interfaces;
using Application.SwitchHandling.Provider.Interfaces;
using FluentValidation;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Interfaces;
using Infrastructure.Persistence.SQLite.Implementations;
using Infrastructure.SwitchHandling.Handler.HPComware5.Implementations;
using Infrastructure.SwitchHandling.Provider.DI.Implementations;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebAPI.Options;
using WebAPI.Services;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddOpenApi();

            builder.Services.AddProblemDetails();

            builder.Services.AddMapster();

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.Load("Application"));

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.Load("Application"));

                cfg.AddOpenBehavior(typeof(ExceptionHandlingBehavior<,>));
                cfg.AddOpenBehavior(typeof(PermissionAuthorizationBehavior<,>));
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });


            builder.Services.AddDbContext<SwitchManagmentDbContext>(opts =>
                opts.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection")));

            builder.Services.AddScoped<ISwitchManagmentDbContext>(provider => provider.GetRequiredService<SwitchManagmentDbContext>());

            builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

            builder.Services.AddScoped<ISwitchHandlerProvider, SwitchHandlerProviderDI>();

            builder.Services.AddKeyedScoped<ISwitchHandler, SwitchHandlerHPComware5>("HP5");

            builder.Services.Scan(typeSourceSelector =>
            {
                typeSourceSelector.FromAssemblies(Assembly.Load("Application"))
                    .AddClasses(c => c.AssignableTo(typeof(IFilterApplier<,>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();

                typeSourceSelector.FromAssemblies(Assembly.Load("Application"))
                    .AddClasses(c => c.AssignableTo(typeof(IValidator<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });

            builder.Services.AddScoped<IDbContextErrorTranslator, DbContextErrorTranslatorSQLite>();

            builder.Services.AddHttpContextAccessor();

            builder.Services.Configure<CurrentUserServiceOptions>(builder.Configuration.GetSection("Roles"));

            /*
            var types = Assembly.Load("Application").GetTypes()
                .Where(t => t.GetInterfaceMap(typeof(IFilterApplier<,>)));
            */

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            /*
            builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
                .AddNegotiate();

            builder.Services.AddAuthorization(options =>
            {
                // By default, all incoming requests will be authorized according to the default policy.
                options.FallbackPolicy = options.DefaultPolicy;
            });
            */


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(opts =>
                    opts.SwaggerEndpoint("/openapi/v1.json", "v1"));
            }

            app.UseHttpsRedirection();

            app.UseStatusCodePages();
            app.UseExceptionHandler();

            //app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
