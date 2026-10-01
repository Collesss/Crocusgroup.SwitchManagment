using Application.Common.Exceptions;
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
            var validationResult = _validators
                .SelectMany(validator => validator.Validate(request).Errors)
                .GroupBy(error => error.PropertyName, error => error.ErrorMessage)
                .ToDictionary(group => group.Key, group => group.ToArray());

            if (validationResult.Count != 0)
                throw new ValidationAppException(validationResult);

            return await next(cancellationToken);
        }
    }
}