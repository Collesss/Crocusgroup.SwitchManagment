using Application.Repository.Interfaces;
using Infrastructure.Persistence.SQLite;
using Infrastructure.Persistence.SQLite.Implementations;
using Mapster;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

            builder.Services.AddMediatR(cfg => 
                cfg.RegisterServicesFromAssembly(Assembly.Load("Application")));


            builder.Services.AddDbContext<SQLiteDbContext>(opts =>
                opts.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection")));

            builder.Services.AddScoped<ISwitchRepository, SwitchRepository>();


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
