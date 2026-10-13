using WebAPI.Models.Dto.Common.Request;

namespace WebAPI.Models.Dto.Common.Response
{
    public class GetListEntityResponse<TFilter, TEntity> : GetListEntityRequest<TFilter>
        where TFilter : class, new()
    {
        public IEnumerable<TEntity> Entities { get; set; }

        public int TotalCount { get; set; }
    }
}
