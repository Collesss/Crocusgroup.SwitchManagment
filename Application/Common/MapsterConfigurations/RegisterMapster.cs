using Application.Repository.Models;
using Application.UseCases.Switches.Commands.Add;
using Mapster;

namespace Application.Common.MapsterConfigurations
{
    public class RegisterMapster : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AdminAddSwitchCommand, SwitchAddDto>();
        }
    }
}
