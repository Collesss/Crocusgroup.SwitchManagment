using FluentValidation;

namespace Application.Ports.Commands.Common
{
    public class CommonConfigurePortCommandValidator<T> : AbstractValidator<T>
        where T : CommonConfigurePortCommand
    {
        public CommonConfigurePortCommandValidator() 
        {
            RuleFor(commonConfigurePortCommand => commonConfigurePortCommand.SwitchId)
                .GreaterThan(0);

            RuleFor(commonConfigurePortCommand => commonConfigurePortCommand.InterfaceName)
                .NotEmpty();
        }
    }
}
