using Application.DbContext.Models;
using Application.Ports.Commands.Access;
using Application.Ports.Commands.Trunk;
using Application.SwitchHandling.Handler.Models;
using Mapster;

namespace Application.Common.MapsterConfigurations
{
    public class RegisterMapster : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ConfigurePortAccessCommand, PortAccessConfig>();
            config.NewConfig<SwitchEntity, PortAccessConfig>();

            config.NewConfig<ConfigurePortTrunkCommand, PortTrunkConfig>();
            config.NewConfig<SwitchEntity, PortTrunkConfig>();
            
            //config.NewConfig<AddSwitchCommand, SwitchDto>();
            //config.NewConfig<GetSwitchesListQuery, GetSwitchesListDto>();
            //config.NewConfig<SwitchSortField, SwitchSortFieldDto>();
            //config.NewConfig<SwitchSortFieldDto, SwitchSortField>();
            //config.NewConfig<SwitchesListDto, SwitchesListResponse>();
        }
    }
}
