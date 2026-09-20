using Application.Common.Exceptions;
using MediatR;

namespace Application.Common.Behaviors
{
    public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next(cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new AppException("An unknown error occurred, see innerException.", e);
            }
        }
    }
}
