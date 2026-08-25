using Application.SwitchHandling.Handler.Interfaces;
using Application.SwitchHandling.Provider.Exceptions;
using Application.SwitchHandling.Provider.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.SwitchHandling.Provider.DI.Implementations
{
    public class SwitchHandlerProviderDI : ISwitchHandlerProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public SwitchHandlerProviderDI(IServiceProvider serviceProvider) =>
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

        public ISwitchHandler GetHandler(string handlerName)
        {
            ArgumentException.ThrowIfNullOrEmpty(handlerName);

            return _serviceProvider.GetKeyedService<ISwitchHandler>(handlerName) ?? 
                throw new NotFoundHandlerProviderException("Handler with this name not found.");
        }
    }
}
