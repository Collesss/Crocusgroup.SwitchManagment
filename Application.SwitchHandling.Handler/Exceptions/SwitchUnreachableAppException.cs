using Application.Common.Exceptions;

namespace Application.SwitchHandling.Handler.Exceptions
{
    public class SwitchUnreachableAppException : AppException
    {
        public SwitchUnreachableAppException() { }

        public SwitchUnreachableAppException(string message) : base(message) { }

        public SwitchUnreachableAppException(string message, Exception innerException) : base(message, innerException) { }
    }
}
