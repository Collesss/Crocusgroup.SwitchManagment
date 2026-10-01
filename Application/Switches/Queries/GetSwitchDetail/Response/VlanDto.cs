namespace Application.Switches.Queries.GetSwitchDetail.Response
{
    public class VlanDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool CanConfigureAsAccess { get; set; }

        public bool CanConfigureAsTrunk { get; set; }
    }
}
