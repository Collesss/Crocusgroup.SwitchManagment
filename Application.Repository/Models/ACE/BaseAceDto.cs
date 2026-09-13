namespace Application.Repository.Models.ACE
{
    public abstract class BaseAceDto<T> where T : Enum
    {
        public int Id { get; set; }

        public int SwitchId { get; set; }

        public string GroupId { get; set; }

        public T RightsMask { get; set; }
    }
}
