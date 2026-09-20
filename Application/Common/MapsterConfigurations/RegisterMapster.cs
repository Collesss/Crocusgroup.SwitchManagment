using Application.Repository.Models.Switch;
using Application.Switches.Commands.Add;
using Application.Switches.Queries.GetSwitchesList;
using Mapster;

namespace Application.Common.MapsterConfigurations
{
    public class RegisterMapster : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AddSwitchCommand, SwitchDto>();
            config.NewConfig<GetSwitchesListQuery, GetSwitchesListDto>();
            config.NewConfig<SwitchSortField, SwitchSortFieldDto>();
            config.NewConfig<SwitchSortFieldDto, SwitchSortField>();
            config.NewConfig<SwitchesListDto, SwitchesListResponse>();
        }
    }
}
