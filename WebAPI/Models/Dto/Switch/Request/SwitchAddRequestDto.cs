using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Dto.Switch.Request
{
    public class SwitchAddRequestDto
    {
        [Required(AllowEmptyStrings = false)]
        public string IpOrName { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string Handler { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string SuperPassword { get; set; }
    }
}
