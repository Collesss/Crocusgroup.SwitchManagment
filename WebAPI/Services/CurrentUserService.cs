using Application.Interfaces;

namespace WebAPI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly HttpContextAccessor _httpContextAccessor;

        public IEnumerable<string> GroupsId => _httpContextAccessor.HttpContext.User.Claims.Select(claim => claim.Value);

        public CurrentUserService(HttpContextAccessor httpContextAccessor) 
        {
            _httpContextAccessor = _httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }
    }
}
