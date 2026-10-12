using FluentValidation;
using System.Reflection;

namespace Application.Common.Query.List
{
    public abstract class CommonListQueryValidator<TQuery, TFilter, TTypeSortFields> : AbstractValidator<TQuery>
        where TQuery : CommonListQuery<TFilter>
        where TFilter : class, new()
    {
        protected virtual HashSet<string> AllowedSortFields { get => new(typeof(TTypeSortFields).GetProperties(BindingFlags.Public | BindingFlags.GetProperty).Select(prop => prop.Name)); }

        public CommonListQueryValidator(IValidator<TFilter> filterValidator) 
        {
            ArgumentNullException.ThrowIfNull(filterValidator, nameof(filterValidator));

            RuleFor(commonListQueryValidator => commonListQueryValidator.Filter)
                .NotNull()
                .SetValidator(filterValidator)
                .When(commonListQueryValidator => commonListQueryValidator.Filter is not null, ApplyConditionTo.CurrentValidator);

            RuleFor(commonListQueryValidator => commonListQueryValidator.SortField)
                .Must(AllowedSortFields.Contains)
                .When(commonListQueryValidator => !string.IsNullOrEmpty(commonListQueryValidator.SortField), ApplyConditionTo.CurrentValidator);

            RuleFor(commonListQueryValidator => commonListQueryValidator.PageSize)
                .InclusiveBetween(1, 100);

            RuleFor(commonListQueryValidator => commonListQueryValidator.PageNumber)
                .GreaterThan(0);
        }
    }
}
