using Application.Common.Exceptions;

namespace Application.DbContext.Exceptions
{
    public class DbContextException : AppException
    {
        public DbContextException() { }

        public DbContextException(string message) : base(message) { }

        public DbContextException(string message, Exception innerException) : base(message, innerException) { }
    }
}
