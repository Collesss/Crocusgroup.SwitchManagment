using Application.CurrentUserService.Interfaces;
using Microsoft.Extensions.Options;
using WebAPI.Options;

namespace WebAPI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IEnumerable<string> _permissions;

        public IEnumerable<string> GroupsIds { get; }

        public bool IsAuthenticated { get; }

        public CurrentUserService(HttpContextAccessor httpContextAccessor, IOptionsSnapshot<CurrentUserServiceOptions> options)
        {
            ArgumentNullException.ThrowIfNull(httpContextAccessor, nameof(httpContextAccessor));

            IsAuthenticated = httpContextAccessor?.HttpContext?.User is not null;

            if (IsAuthenticated)
            {
                GroupsIds = httpContextAccessor.HttpContext.User?.Claims?.Select(claim => claim.Value);

                _permissions = options?.Value?
                    .Where(role => role.GroupsSIDs.Any(groupSid => GroupsIds.Contains(groupSid)))
                    .SelectMany(role => role.Permissions);
            }

            _permissions ??= [];
            GroupsIds ??= [];
        }

        public bool HasPermission(params IEnumerable<string> permissions)
        {
            ArgumentNullException.ThrowIfNull(permissions);
            ArgumentOutOfRangeException.ThrowIfLessThan(permissions.Count(), 1);
            _ = permissions.Any(CheckEmptyStr);

            return _permissions.Contains("*") || _permissions.Any(permission => permissions.Contains(permission));
        }

        private static bool CheckEmptyStr(string str)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(str);

            return false;
        }
    }
}