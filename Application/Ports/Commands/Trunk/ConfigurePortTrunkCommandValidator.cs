using Application.Ports.Commands.Common;
using FluentValidation;

namespace Application.Ports.Commands.Trunk
{
    public class ConfigurePortTrunkCommandValidator : CommonConfigurePortCommandValidator<ConfigurePortTrunkCommand>
    {
        public ConfigurePortTrunkCommandValidator()
        {
            RuleFor(configurePortTrunkCommand => configurePortTrunkCommand.TrunkVlans)
                .NotNull()
                .ForEach(rule => rule.ExclusiveBetween(1, 4095))
                .Must(vlans => vlans.CountBy(vlan => vlan).Any(vlansCount => vlansCount.Value > 1))
                    .WithMessage("Array \"{PropertyName}\" be contains unique elements.");
        }
    }
}
