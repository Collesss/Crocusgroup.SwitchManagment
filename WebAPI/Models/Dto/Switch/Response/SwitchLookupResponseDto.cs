namespace WebAPI.Models.Dto.Switch.Response
{
    public class SwitchLookupResponseDto
    {
        public int Id { get; set; }

        public string IpOrName { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string Handler { get; set; }
    }
}
