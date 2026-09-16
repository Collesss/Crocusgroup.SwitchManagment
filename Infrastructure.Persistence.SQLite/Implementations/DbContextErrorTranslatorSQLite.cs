using Application.Common.Exceptions;
using Application.DbContext.Exceptions;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.SQLite.Implementations
{
    public class DbContextErrorTranslatorSQLite : IDbContextErrorTranslator
    {
        public AppException Translate(Exception exception)
        {
            return exception switch 
            {
                DbUpdateException e => new NotFoundDbContextException("", exception),
                _ => throw new AppException("Unknow error.", exception)
            };
        }
    }
}
