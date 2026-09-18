using Application.Common.Exceptions;
using Application.CurrentUserService.Interfaces;
using Application.CurrentUserService.Security;
using MediatR;
using System.Reflection;

namespace Application.Common.Behaviors
{
    public class PermissionAuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ICurrentUserService _currentUserService;

        public PermissionAuthorizationBehavior(ICurrentUserService currentUserService) 
        {
            _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_currentUserService.IsAuthenticated)
                throw new UnauthenticatedAppException("User not authenticated.");

            if(typeof(TRequest).GetCustomAttribute<RequirePermissionAttribute>() is RequirePermissionAttribute attr && !_currentUserService.HasPermission(attr.Premission))
                throw new AccessDeniedAppException("Access denied.");

            return await next(cancellationToken);
        }
    }
}
