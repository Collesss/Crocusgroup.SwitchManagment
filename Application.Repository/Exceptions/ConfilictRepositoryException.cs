namespace Application.Repository.Exceptions
{
    public class ConfilictRepositoryException : RepositoryException
    {
        public ConfilictRepositoryException() { }

        public ConfilictRepositoryException(string message) : base(message) { }

        public ConfilictRepositoryException(string message, Exception innerException) : base(message, innerException) { }
    }
}
