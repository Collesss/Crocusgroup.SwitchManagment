using FluentValidation;

namespace Application.ACL.Ports.Queries.GetPortAcesList.Filter
{
    public class PortAceFilterValidator : AbstractValidator<PortAceFilter>
    {
        public PortAceFilterValidator() 
        {
            RuleFor(portAceFilterValidator => portAceFilterValidator.SearchByIntefaceName)
                .MaximumLength(100);
        }
    }
}
