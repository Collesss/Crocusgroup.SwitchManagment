namespace Application.Repository.Exceptions
{
    public class SwitchRepositoryException : RepositoryException
    {
        public SwitchRepositoryException() { }

        public SwitchRepositoryException(string message) : base(message) { }

        public SwitchRepositoryException(string message, Exception innerException) : base(message, innerException) { }
    }
}
