namespace Application.DbContext.Models.ACE
{
    public class BaseAceEntity<T> where T : Enum
    {
        public int Id { get; set; }

        public int SwitchId { get; set; }

        public SwitchEntity Switch {  get; set; }

        public string GroupId { get; set; }

        public T RightsMask { get; set; }
    }
}
