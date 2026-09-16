namespace Application.Repository.Exceptions
{
    public class ConfilictRepositoryException : RepositoryException
    {
        public ConfilictRepositoryException() { }

        public ConfilictRepositoryException(string repository, string action) : base(repository, action) { }

        public ConfilictRepositoryException(string message) : base(message) { }

        public ConfilictRepositoryException(string message, string repository, string action) : base(message, repository, action) { }

        public ConfilictRepositoryException(string message, Exception innerException) : base(message, innerException) { }

        public ConfilictRepositoryException(string message, Exception innerException, string repository, string action) : base(message, innerException, repository, action) { }
    }
}
