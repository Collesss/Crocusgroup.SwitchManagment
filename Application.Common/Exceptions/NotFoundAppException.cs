namespace Application.Common.Exceptions
{
    public class NotFoundAppException : AppException
    {
        public NotFoundAppException() { }

        public NotFoundAppException(string message) : base(message) { }

        public NotFoundAppException(string message, Exception innerException) : base(message, innerException) { }
    }
}
