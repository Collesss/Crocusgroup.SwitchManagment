using Application.Common.Exceptions;

namespace Application.SwitchHandling.Handler.Exceptions
{
    public class WrongLoginOrPassAppException : AppException
    {
        public WrongLoginOrPassAppException() { }

        public WrongLoginOrPassAppException(string message) : base(message) { }

        public WrongLoginOrPassAppException(string message, Exception innerException) : base(message, innerException) { }
    }
}
