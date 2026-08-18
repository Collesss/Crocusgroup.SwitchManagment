namespace Application.Repository.Models
{
    public class GetSwitchesListDto
    {
        public string SearchByIpOrName { get; set; }

        public string SearchByLocation { get; set; }

        public string SearchByDescription { get; set; }

        public string SearchByHandler { get; set; }

        public SwitchSortFieldDto SortField { get; set; } = SwitchSortFieldDto.Id;

        public bool SortAsc { get; set; } = true;

        public int PageSize { get; set; } = 10;

        public int PageNumber { get; set; } = 1;
    }
}
