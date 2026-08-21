namespace Application.Repository.Exceptions
{
    public class NotFoundRepositoryException : RepositoryException
    {
        public NotFoundRepositoryException() { }

        public NotFoundRepositoryException(string message) : base(message) { }

        public NotFoundRepositoryException(string message, Exception innerException) : base(message, innerException) { }

    }
}
