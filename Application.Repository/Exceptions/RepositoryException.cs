using Application.Repository.Exceptions.Enums;

namespace Application.Repository.Exceptions
{
    public class RepositoryException : Exception
    {
        public RepositoryErrorCode BaseErrorCode { get; private set; }

        public RepositoryException() { }

        public RepositoryException(RepositoryErrorCode errorCode) : base(GetMessage(errorCode))
        {
            BaseErrorCode = errorCode;
        }

        public RepositoryException(RepositoryErrorCode errorCode, Exception innerException) : base(GetMessage(errorCode), innerException)
        {
            BaseErrorCode = errorCode;
        }

        public RepositoryException(string message) : base(message) { }

        public RepositoryException(string message, RepositoryErrorCode errorCode) : base(message) 
        {
            BaseErrorCode = errorCode;
        }

        public RepositoryException(string message, Exception innerException) : base(message, innerException) { }

        public RepositoryException(string message, Exception innerException, RepositoryErrorCode errorCode) : base(message, innerException) 
        {
            BaseErrorCode = errorCode;
        }

        private static string GetMessage(RepositoryErrorCode errorCode) =>
            errorCode switch 
            {
                _ => "Unknow"
            };
    }
}
