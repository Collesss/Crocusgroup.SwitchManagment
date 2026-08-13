namespace Application.UseCases.Switches.Commands.Add
{
    public class AddSwitchCommand
    {
        public string IpOrHostName { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }
    }
}
