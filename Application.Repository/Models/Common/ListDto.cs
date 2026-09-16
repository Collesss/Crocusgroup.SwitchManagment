namespace Application.Repository.Models.Common
{
    /// <summary>
    /// Paged, sort and filtered result.
    /// </summary>
    /// <typeparam name="S">Sort enum.</typeparam>
    /// <typeparam name="F">Filter class.</typeparam>
    /// <typeparam name="R">Result class.</typeparam>
    public class ListDto<S, F, R> : GetListDto<S, F>
        where S : Enum 
        where F : class, new()
        where R : class
    {
        public int TotalCount { get; set; }

        public IEnumerable<R> Entities { get; set; }
    }
}
