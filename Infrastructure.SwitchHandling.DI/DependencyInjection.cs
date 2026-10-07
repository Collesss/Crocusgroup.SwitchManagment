using Application.SwitchHandling.Handler.Interfaces;
using Application.SwitchHandling.Provider.Interfaces;
using Infrastructure.SwitchHandling.Handler.HPComware5.Implementations;
using Infrastructure.SwitchHandling.Provider.DI.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.SwitchHandling.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSwitchHandlingInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ISwitchHandlerProvider, SwitchHandlerProviderDI>();

            services.AddKeyedScoped<ISwitchHandler, SwitchHandlerHPComware5>("HP5");

            return services;
        }

    }
}
