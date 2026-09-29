using FluentValidation;
using MediatR;

namespace Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<AbstractValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<AbstractValidator<TRequest>> validators)
        {
            _validators = validators ?? throw new ArgumentException(nameof(validators));
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            foreach (var validator in _validators)
                validator.ValidateAndThrow(request);

            return await next(cancellationToken);
        }
    }
}
