using Application.Common.Exceptions;

namespace Application.Repository.Exceptions
{
    public class RepositoryException : AppException
    {
        public string Repository {  get; private set; }

        public string Action { get; private set; }

        public RepositoryException() { }

        public RepositoryException(string repository, string action) 
        {
            Repository = repository;
            Action = action;
        }

        public RepositoryException(string message) : base(message) { }

        public RepositoryException(string message, string repository, string action) : base(message)
        {
            Repository = repository;
            Action = action;
        }

        public RepositoryException(string message, Exception innerException) : base(message, innerException) { }

        public RepositoryException(string message, Exception innerException, string repository, string action) : base(message, innerException)
        {
            Repository = repository;
            Action = action;
        }
    }
}
