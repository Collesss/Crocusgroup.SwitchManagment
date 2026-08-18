namespace Application.Repository.Models
{
    public class SwitchesListDto
    {
        public string SearchByIpOrName { get; set; }

        public string SearchByLocation { get; set; }

        public string SearchByDescription { get; set; }

        public string SearchByHandler { get; set; }

        public SwitchSortFieldDto SortField { get; set; }

        public bool SortAsc { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public int TotalCount { get; set; }

        public IEnumerable<SwitchLookupDto> Switches { get; set; }
    }
}