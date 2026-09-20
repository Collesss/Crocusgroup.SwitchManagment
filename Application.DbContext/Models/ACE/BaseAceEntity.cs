namespace Application.DbContext.Models.ACE
{
    public class BaseAceEntity<T> : BaseEntity where T : Enum
    {

        public int SwitchId { get; set; }

        public SwitchEntity Switch {  get; set; }

        public string GroupId { get; set; }

        public T RightsMask { get; set; }
    }
}
