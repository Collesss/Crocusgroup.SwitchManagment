namespace Application.Common.Exceptions
{
    public class UnauthenticatedAppException : AppException
    {
        public UnauthenticatedAppException() { }

        public UnauthenticatedAppException(string message) : base(message) { }

        public UnauthenticatedAppException(string message, Exception innerException) : base(message, innerException) { }
    }
}
