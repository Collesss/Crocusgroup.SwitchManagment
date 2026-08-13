namespace Infrastructure.Persistence.SQLite.Models
{
    public class SwitchDbEntity
    {
        public int Id { get; set; }

        public string IpOrName { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string Handler { get; set; }

        public string Login {  get; set; }

        public string Password { get; set; }

        public string SuperPassword { get; set; }
    }
}
