namespace Application.Common.Query.List
{
    /// <summary>
    /// Query common for get list entities.
    /// </summary>
    /// <typeparam name="TFilter">Type filter.</typeparam>
    /// <typeparam name="TSortField">Enum contains fields for sort.</typeparam>
    public abstract class CommonListQuery<TFilter, TSortField>
        where TFilter : class, new()
        where TSortField : Enum
    {
        public TFilter Filter { get; set; } = new();

        public TSortField SortField { get; set; }

        public bool SortAsc { get; set; } = true;

        /// <summary>
        /// Min 1, Max 100.
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Min 1
        /// </summary>
        public int PageNumber { get; set; } = 1;
    }
}