namespace Application.DbContext.Models
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Entity id, cant be less than 1.
        /// </summary>
        public int Id { get; set; }
    }
}
