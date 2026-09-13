namespace Application.Repository.Models.Switch
{
    public class SwitchSummaryDto
    {
        public int Id { get; set; }

        public string IpOrName { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string Handler { get; set; }
    }
}
