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

            try
            {
                return _serviceProvider.GetKeyedService<ISwitchHandler>(handlerName) ??
                    throw new NotFoundHandlerProviderException("Handler with this name not found.");
            }
            catch(NotFoundHandlerProviderException)
            {
                throw;
            }
            catch(Exception e)
            {
                throw new HandlerProviderException("An unknown error occurred while getting the handler, see inner exception.", e);
            }
        }
    }
}
