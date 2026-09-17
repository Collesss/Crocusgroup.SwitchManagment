using Application.DbContext.Exceptions;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IDbContextErrorTranslator
    {
        /// <summary>
        /// Handler DbContext errors.
        /// </summary>
        /// <param name="exception">Db exception.</param>
        public DbContextException Translate(Exception exception);
    }
}