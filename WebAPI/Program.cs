using Application.Common;
using Application.CurrentUserService.Interfaces;
using Infrastructure.Persistence.DI;
using Infrastructure.SwitchHandling.DI;
using Microsoft.EntityFrameworkCore;
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


            builder.Services.AddApplication();
            builder.Services.AddPersistance(builder.Configuration.GetConnectionString("SQLiteConnection"));
            builder.Services.AddSwitchHandlingInfrastructure();


            builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
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
