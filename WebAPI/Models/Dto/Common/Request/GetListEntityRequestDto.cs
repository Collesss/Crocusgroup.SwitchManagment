using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Dto.Common.Request
{
    public class GetListEntityRequestDto<TFilter>
        where TFilter : class, new()
    {
        public TFilter Filter { get; set; } = new();

        public string SortField { get; set; }

        public bool SortAsc { get; set; } = true;

        /// <summary>
        /// Min 1, Max 100.
        /// </summary>
        [Range(1, 100)]
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Min 1
        /// </summary>
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; } = 1;
    }
}
