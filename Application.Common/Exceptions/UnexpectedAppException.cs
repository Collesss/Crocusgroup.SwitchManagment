namespace Application.Common.Exceptions
{
    public class UnexpectedAppException : AppException
    {
        public UnexpectedAppException() { }

        public UnexpectedAppException(string message) : base(message) { }

        public UnexpectedAppException(string message, Exception innerException) : base(message, innerException) { }
    }
}
