using Application.Common.Exceptions;

namespace Application.SwitchHandling.Handler.Exceptions
{
    public class WrongInterfaceAppException : AppException
    {
        public WrongInterfaceAppException() { }

        public WrongInterfaceAppException(string message) : base(message) { }

        public WrongInterfaceAppException(string message, Exception innerException) : base(message, innerException) { }
    }
}
