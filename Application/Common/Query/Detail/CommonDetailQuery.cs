namespace Application.Common.Query.Detail
{
    /// <summary>
    /// Common get detail query
    /// </summary>
    public abstract class CommonDetailQuery
    {
        /// <summary>
        /// Id entity, cant be less 1
        /// </summary>
        public int Id { get; set; }
    }
}