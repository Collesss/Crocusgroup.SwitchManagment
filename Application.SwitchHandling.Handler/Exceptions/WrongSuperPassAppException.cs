using Application.Common.Exceptions;

namespace Application.SwitchHandling.Handler.Exceptions
{
    public class WrongSuperPassAppException : AppException
    {
        public WrongSuperPassAppException() { }

        public WrongSuperPassAppException(string message) : base(message) { }

        public WrongSuperPassAppException(string message, Exception innerException) : base(message, innerException) { }
    }
}
