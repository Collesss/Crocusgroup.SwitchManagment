namespace Application.ACL.Common
{
    public class CommonAceDto<T> where T : Enum
    {
        public int SwitchId { get; set; }

        public string GroupId { get; set; }

        public T RightsMask { get; set; }
    }
}