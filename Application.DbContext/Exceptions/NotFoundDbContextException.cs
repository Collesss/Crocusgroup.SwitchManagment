namespace Application.DbContext.Exceptions
{
    public class NotFoundDbContextException : DbContextException
    {
        public NotFoundDbContextException() { }

        public NotFoundDbContextException(string message) : base(message) { }

        public NotFoundDbContextException(string message, Exception innerException) : base(message, innerException) { }
    }
}
