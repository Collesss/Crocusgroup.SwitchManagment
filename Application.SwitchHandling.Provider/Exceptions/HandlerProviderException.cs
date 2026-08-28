using Application.Common.Exceptions;

namespace Application.SwitchHandling.Provider.Exceptions
{
    public class HandlerProviderException : AppException
    {
        public HandlerProviderException() : base() { }

        public HandlerProviderException(string message) : base(message) { }

        public HandlerProviderException(string message, Exception innerException) : base(message, innerException) { }
    }
}
