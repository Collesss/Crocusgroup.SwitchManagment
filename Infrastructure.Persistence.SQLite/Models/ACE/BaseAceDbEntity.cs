namespace Infrastructure.Persistence.SQLite.Models.ACE
{
    public class BaseAceDbEntity<T> where T : Enum
    {
        public int Id { get; set; }

        public int SwitchId { get; set; }

        public SwitchDbEntity Switch {  get; set; }

        public string GroupId { get; set; }

        public T RightsMask { get; set; }
    }
}
