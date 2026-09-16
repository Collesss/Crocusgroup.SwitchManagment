namespace Application.Interfaces
{
    public interface ICurrentUserService
    {
        public IEnumerable<string> GroupsId { get; }
    }
}
