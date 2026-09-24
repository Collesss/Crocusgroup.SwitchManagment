namespace Application.DbContext.Models.ACE.Switch
{
    [Flags]
    public enum SwitchRights
    {
        None        = 0b0000_0000,
        SummaryView = 0b0000_0001,
        DetailView  = 0b0000_0010
    }
}
