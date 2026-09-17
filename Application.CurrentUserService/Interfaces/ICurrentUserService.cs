namespace Application.CurrentUserService.Interfaces
{
    public interface ICurrentUserService
    {
        public IEnumerable<string> GroupsId { get; }

        public bool IsAdmin { get; }
    }
}
