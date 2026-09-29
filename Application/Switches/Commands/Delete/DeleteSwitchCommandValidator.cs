using FluentValidation;

namespace Application.Switches.Commands.Delete
{
    public class DeleteSwitchCommandValidator : AbstractValidator<DeleteSwitchCommand>
    {
        public DeleteSwitchCommandValidator() 
        {
            RuleFor(deleteSwitchCommand => deleteSwitchCommand.Id)
                .GreaterThan(0);
        }
    }
}
