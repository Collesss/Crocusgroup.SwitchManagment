using Application.SwitchHandling.Handler.Interfaces;

namespace Application.SwitchHandling.Provider.Interfaces
{
    public interface ISwitchHandlerProvider
    {
        /// <summary>
        /// Return ISwitchHandler by name, if not exsist or while get thrown exception return null.
        /// </summary>
        /// <param name="handlerName">Handler name/</param>
        /// <returns>SwitchHandler, if not exsist null.</returns>
        public ISwitchHandler GetHandler(string handlerName);
    }
}
