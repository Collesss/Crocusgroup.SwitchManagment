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
        /// <exception cref="ArgumentException">Throw if param "handlerName" is empty or contains only whitespaces.</exception>
        /// <exception cref="FailedLoadingHandlerException">Thrown if an error occurs while loading the handler.</exception>
        /// <exception cref="UndefinedHandlerException">Throw if handler not defined.</exception>
        /// <returns>SwitchHandler</returns>
        public ISwitchHandler GetHandler(string handlerName);
    }
}
