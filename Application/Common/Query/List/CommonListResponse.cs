namespace Application.Common.Query.List
{
    public abstract class CommonListResponse<TEntity, TFilter> : CommonListQuery<TFilter>
        where TEntity : class
        where TFilter : class, new()
    {
        public IEnumerable<TEntity> Entities { get; set; }

        public int TotalCount { get; set; }
    }
}
