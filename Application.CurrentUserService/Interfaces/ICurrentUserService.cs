namespace Application.CurrentUserService.Interfaces
{
    public interface ICurrentUserService
    {
        public IEnumerable<string> GroupsIds { get; }

        /// <summary>
        /// Method return True if user contains any permision in array "permissions", else false.
        /// </summary>
        /// <param name="permissions">Array need permissions.</param>
        /// <exception cref="ArgumentNullException">Throw if array "permissions" is null or contains null elements.</exception>
        /// <exception cref="ArgumentException">Throw if array "permissions" contains empty or whgitespace string.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throw if count elemnts in array "permissions" less than 1.</exception>
        /// <returns>True if user contains any permision in array "permissions", else false.</returns>
        public bool HasPermission(params IEnumerable<string> permissions);

        public bool IsAuthenticated { get; }
    }
}
