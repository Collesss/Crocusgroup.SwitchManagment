namespace Application.Repository.Models.Switch
{
    public class GetSwitchesFilterDto
    {
        public string SearchByIpOrName { get; set; }

        public string SearchByLocation { get; set; }

        public string SearchByDescription { get; set; }

        public string SearchByHandler { get; set; }

        public IEnumerable<string> UserGropus { get; set; }
    }
}
