using FluentValidation;

namespace Application.Switches.Queries.GetSwitchesList.Filter
{
    public class SwitchFilterValidator : AbstractValidator<SwitchFilter>
    {
        public SwitchFilterValidator() 
        {
            RuleFor(switchFilter => switchFilter.SearchByIpOrName)
                .MaximumLength(100);

            RuleFor(switchFilter => switchFilter.SearchByLocation)
                .MaximumLength(250);

            RuleFor(switchFilter => switchFilter.SearchByDescription)
                .MaximumLength(500);

            RuleFor(switchFilter => switchFilter.SearchByHandler)
                .MaximumLength(100);
        }
    }
}
