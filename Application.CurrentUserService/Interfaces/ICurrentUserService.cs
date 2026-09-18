namespace Application.CurrentUserService.Interfaces
{
    public interface ICurrentUserService
    {
        public IEnumerable<string> GroupsIds { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="permissions"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns></returns>
        public bool HasPermission(params IEnumerable<string> permissions);

        public bool IsAuthenticated { get; }
    }
}
