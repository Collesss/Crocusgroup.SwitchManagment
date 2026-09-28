using Application.Common.Exceptions;

namespace Application.SwitchHandling.Provider.Exceptions
{
    public class UndefinedHandlerException : AppException
    {
        public UndefinedHandlerException() : base() { }

        public UndefinedHandlerException(string message) : base(message) { }

        public UndefinedHandlerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
