using WebAPI.Models.Dto.Common.Request;

namespace WebAPI.Models.Dto.Common.Response
{
    public class GetListEntityResponseDto<TFilter, TEntity> : GetListEntityRequestDto<TFilter>
        where TFilter : class, new()
    {
        public IEnumerable<TEntity> Entities { get; set; }

        public int TotalCount { get; set; }
    }
}
