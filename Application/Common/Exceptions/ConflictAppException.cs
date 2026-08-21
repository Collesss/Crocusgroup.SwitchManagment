namespace Application.Common.Exceptions
{
    public class ConflictAppException : AppException
    {
        public ConflictAppException() { }

        public ConflictAppException(string message) : base(message) { }

        public ConflictAppException(string message, Exception innerException) : base(message, innerException) { }
    }
}
