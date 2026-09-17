using Application.CurrentUserService.Interfaces;
using Microsoft.Extensions.Options;
using WebAPI.Options;

namespace WebAPI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly HttpContextAccessor _httpContextAccessor;

        public IEnumerable<string> GroupsId { get; }

        public bool IsAdmin { get; }

        public CurrentUserService(HttpContextAccessor httpContextAccessor, IOptionsSnapshot<CurrentUserServiceOptions> options) 
        {
            GroupsId = _httpContextAccessor?.HttpContext?.User?.Claims?.Select(claim => claim.Value) ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            IsAdmin = GroupsId.All(group => group == (options?.Value?.AdminGroupId ?? throw new ArgumentNullException(nameof(options))));
        }
    }
}
