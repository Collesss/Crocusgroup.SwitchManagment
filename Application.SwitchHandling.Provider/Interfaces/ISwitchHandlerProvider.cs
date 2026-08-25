using Application.SwitchHandling.Handler.Interfaces;
using Application.SwitchHandling.Provider.Exceptions;


namespace Application.SwitchHandling.Provider.Interfaces
{
    public interface ISwitchHandlerProvider
    {
        /// <summary>
        /// Return ISwitchHandler by name.
        /// </summary>
        /// <param name="handlerName">Handler name/</param>
        /// <exception cref="ArgumentNullException">Throw if param "handlerName" is null.</exception>
        /// <exception cref="ApplicationException">Throw if param "handlerName" is empty or contains only whitespaces.</exception>
        /// <exception cref="NotFoundHandlerProviderException">Throw if handler not found.</exception>
        /// <returns>SwitchHandler</returns>
        public ISwitchHandler GetHandler(string handlerName);
    }
}
