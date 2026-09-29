using FluentValidation;

namespace Application.Switches.Commands.Add
{
    public class AddSwitchCommandValidator : AbstractValidator<AddSwitchCommand>
    {
        public AddSwitchCommandValidator() 
        {
            RuleFor(addSwitchCommand => addSwitchCommand.IpOrName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(addSwitchCommand => addSwitchCommand.Location)
                .MaximumLength(250);

            RuleFor(addSwitchCommand => addSwitchCommand.Description)
                .MaximumLength(500);

            RuleFor(addSwitchCommand => addSwitchCommand.Handler)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(addSwitchCommand => addSwitchCommand.Login)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(addSwitchCommand => addSwitchCommand.Password)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(addSwitchCommand => addSwitchCommand.SuperPassword)
                .Must(value => value is null || !string.IsNullOrWhiteSpace(value))
                .WithMessage("\"{PropertyName}\" cannot be empty or contains only whitespace.")
                .MaximumLength(150);
        }
    }
}