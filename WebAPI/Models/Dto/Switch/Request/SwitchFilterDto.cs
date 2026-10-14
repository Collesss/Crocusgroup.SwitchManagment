using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Dto.Switch.Request
{
    public class SwitchFilterDto
    {
        /// <summary>
        /// Filter by IpOrName, cant be great than 100, apply if not null, empty or contains only whitespace.
        /// </summary>
        [MaxLength(100)]
        public string SearchByIpOrName { get; set; }

        /// <summary>
        /// Filter by Location, cant be great than 250, apply if not null, empty or contains only whitespace.
        /// </summary>
        [MaxLength(250)]
        public string SearchByLocation { get; set; }

        /// <summary>
        /// Filter by Description, cant be great than 500, apply if not null, empty or contains only whitespace.
        /// </summary>
        [MaxLength(500)]
        public string SearchByDescription { get; set; }

        /// <summary>
        /// Filter by Handler, cant be great than 100, apply if not null, empty or contains only whitespace.
        /// </summary>
        [MaxLength(100)]
        public string SearchByHandler { get; set; }
    }
}
