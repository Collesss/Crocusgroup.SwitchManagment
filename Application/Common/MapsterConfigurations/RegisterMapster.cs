using Application.Repository.Models;
using Application.Switches.Commands.Add;
using Application.Switches.Queries.GetSwitchesList;
using Mapster;

namespace Application.Common.MapsterConfigurations
{
    public class RegisterMapster : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AdminAddSwitchCommand, AddSwitchDto>();
            config.NewConfig<AdminAddSwitchCommand, AddSwitchDto>();
            config.NewConfig<AdminGetSwitchesListQuery, GetSwitchesListDto>();
            config.NewConfig<SwitchSortField, SwitchSortFieldDto>();
            config.NewConfig<SwitchSortFieldDto, SwitchSortField>();
            config.NewConfig<SwitchesListDto, AdminSwitchesListVm>();
        }
    }
}
