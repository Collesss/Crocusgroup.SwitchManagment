using Application.Common.Exceptions;

namespace Application.SwitchHandling.Provider.Exceptions
{
    public class FailedLoadingHandlerException : AppException
    {
        public FailedLoadingHandlerException() : base() { }

        public FailedLoadingHandlerException(string message) : base(message) { }

        public FailedLoadingHandlerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
