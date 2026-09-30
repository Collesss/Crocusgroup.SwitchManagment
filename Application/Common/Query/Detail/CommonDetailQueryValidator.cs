using FluentValidation;

namespace Application.Common.Query.Detail
{
    public abstract class CommonDetailQueryValidator<T> : AbstractValidator<T>
        where T : CommonDetailQuery
    {
        public CommonDetailQueryValidator() 
        {
            RuleFor(commonDetailQuery => commonDetailQuery.Id)
                .GreaterThan(1);
        }
    }
}
