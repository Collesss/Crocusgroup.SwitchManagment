using Application.Repository.Exceptions.Enums;

namespace Application.Repository.Exceptions
{
    public class RepositoryException : Exception
    {
        public ErrorCode ErrorCode { get; private set; }

        public RepositoryException() { }

        public RepositoryException(ErrorCode errorCode) : base(GetMessage(errorCode))
        {
            ErrorCode = errorCode;
        }

        public RepositoryException(ErrorCode errorCode, Exception innerException) : base(GetMessage(errorCode), innerException)
        {
            ErrorCode = errorCode;
        }

        public RepositoryException(string message) : base(message) { }

        public RepositoryException(string message, ErrorCode errorCode) : base(message) 
        {
            ErrorCode = errorCode;
        }

        public RepositoryException(string message, Exception innerException) : base(message, innerException) { }

        public RepositoryException(string message, Exception innerException, ErrorCode errorCode) : base(message, innerException) 
        {
            ErrorCode = errorCode;
        }

        private static string GetMessage(ErrorCode errorCode) =>
            errorCode switch 
            {
                _ => "Unknow"
            };
    }
}
