namespace Application.DbContext.Exceptions
{
    public class ConfilictDbContextException : DbContextException
    {
        public ConfilictDbContextException() { }

        public ConfilictDbContextException(string message) : base(message) { }

        public ConfilictDbContextException(string message, Exception innerException) : base(message, innerException) { }
    }
}
