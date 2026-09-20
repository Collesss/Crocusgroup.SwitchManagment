namespace Application.Common.Query
{
    public abstract class CommonListResponse<TEntity, TFilter, TSortField> : CommonListQuery<TFilter, TSortField>
        where TEntity : class
        where TFilter : class, new()
        where TSortField : Enum
    {
        public IEnumerable<TEntity> Entities { get; set; }

        public int TotalCount { get; set; }
    }
}
