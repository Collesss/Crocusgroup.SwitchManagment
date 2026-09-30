using Application.Ports.Commands.Common;
using FluentValidation;

namespace Application.Ports.Commands.Access
{
    public class ConfigurePortAccessCommandValidator : CommonConfigurePortCommandValidator<ConfigurePortAccessCommand>
    {
        public ConfigurePortAccessCommandValidator() 
        {
            RuleFor(configurePortAccessCommand => configurePortAccessCommand.AccessVlan)
                .ExclusiveBetween(1, 4095);
        }
    }
}
