namespace Application.Repository.Exceptions
{
    public class NotFoundRepositoryException : RepositoryException
    {
        public NotFoundRepositoryException() { }

        public NotFoundRepositoryException(string repository, string action) : base(repository, action) { }

        public NotFoundRepositoryException(string message) : base(message) { }

        public NotFoundRepositoryException(string message, string repository, string action) : base(message, repository, action) { }

        public NotFoundRepositoryException(string message, Exception innerException) : base(message, innerException) { }

        public NotFoundRepositoryException(string message, Exception innerException, string repository, string action) : base(message, innerException, repository, action) { }
    }
}
