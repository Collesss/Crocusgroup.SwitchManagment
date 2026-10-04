using Application.Common.Behaviors;
using Application.Common.Interfaces;
using FluentValidation;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMapster();
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

                configuration.AddOpenBehavior(typeof(ExceptionHandlingBehavior<,>));
                configuration.AddOpenBehavior(typeof(PermissionAuthorizationBehavior<,>));
                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.Scan(typeSourceSelector =>
            {
                typeSourceSelector.FromAssemblies(Assembly.GetExecutingAssembly())
                    .AddClasses(c => c.AssignableTo(typeof(IFilterApplier<,>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();

                typeSourceSelector.FromAssemblies(Assembly.GetExecutingAssembly())
                    .AddClasses(c => c.AssignableTo(typeof(IValidator<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });


            return services;
        }
    }
}
