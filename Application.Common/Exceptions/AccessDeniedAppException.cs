namespace Application.Common.Exceptions
{
    public class AccessDeniedAppException : AppException
    {
        public AccessDeniedAppException() { }

        public AccessDeniedAppException(string message) : base(message) { }

        public AccessDeniedAppException(string message, Exception innerException) : base(message, innerException) { }
    }
}
