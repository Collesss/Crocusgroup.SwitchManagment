namespace Application.Repository.Models.ACE.Switch
{
    [Flags]
    public enum SwitchRightsDto
    {
        SummaryView = 0b0000_0001,
        DetailView  = 0b0000_0010
    }
}
