namespace Application.Repository.Models.Common
{
    /// <summary>
    /// Paged, sort and filtered request.
    /// </summary>
    /// <typeparam name="S">Sort enum.</typeparam>
    /// <typeparam name="F">Filter class.</typeparam>
    public class GetListDto<S, F>
        where S : Enum
        where F : class, new()
    {
        public F Filter { get; set; } = new F();

        public S SortField { get; set; }

        public bool SortAsc { get; set; } = true;

        public int PageSize { get; set; } = 10;

        public int PageNumber { get; set; } = 1;
    }
}