using FluentValidation;

namespace Application.ACL.Common.Filter
{
    public class CommonAceFilterValidator<T> : AbstractValidator<T>
        where T : CommonAceFilter
    {
        public CommonAceFilterValidator() 
        {
            RuleFor(commonAceFilterValidator => commonAceFilterValidator.SwitchId)
                .GreaterThan(0);

            RuleFor(commonAceFilterValidator => commonAceFilterValidator.SearchByGroupId)
                .MaximumLength(100);
        }
    }
}
