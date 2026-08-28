using Application.Common.Exceptions;

namespace Application.SwitchHandling.Handler.Exceptions
{
    public class SwitchHandlerException : AppException
    {
        public SwitchHandlerException() { }

        public SwitchHandlerException(string message) : base(message) { }

        public SwitchHandlerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
