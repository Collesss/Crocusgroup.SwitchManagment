using FluentValidation;

namespace Application.Common.Query.List
{
    public abstract class CommonListQueryValidator<TQuery, TFilter, TSortField> : AbstractValidator<TQuery>
        where TQuery : CommonListQuery<TFilter, TSortField>
        where TFilter : class, new()
        where TSortField : Enum
    {
        public CommonListQueryValidator(AbstractValidator<TFilter> filterValidator) 
        {
            ArgumentNullException.ThrowIfNull(filterValidator, nameof(filterValidator));

            RuleFor(commonListQueryValidator => commonListQueryValidator.Filter)
                .NotNull()
                .SetValidator(filterValidator)
                .When(commonListQueryValidator => commonListQueryValidator.Filter is not null, ApplyConditionTo.CurrentValidator);

            RuleFor(commonListQueryValidator => commonListQueryValidator.PageSize)
                .InclusiveBetween(1, 100);

            RuleFor(commonListQueryValidator => commonListQueryValidator.PageNumber)
                .GreaterThan(0);
        }
    }
}
