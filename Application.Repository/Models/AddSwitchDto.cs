namespace Application.Repository.Models
{
    public class AddSwitchDto
    {
        public string IpOrName { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string Handler { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string SuperPassword { get; set; }
    }
}
