using Application.Common.Exceptions;

namespace Application.Repository.Exceptions
{
    public class RepositoryException : AppException
    {
        public RepositoryException() { }

        public RepositoryException(string message) : base(message) { }

        public RepositoryException(string message, Exception innerException) : base(message, innerException) { }
    }
}
