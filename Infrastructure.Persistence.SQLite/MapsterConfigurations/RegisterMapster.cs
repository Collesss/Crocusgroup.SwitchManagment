using Application.Repository.Models;
using Infrastructure.Persistence.SQLite.Models;
using Mapster;

namespace Infrastructure.Persistence.SQLite.MapsterConfiguration
{
    public class RegisterMapster : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<SwitchDbEntity, SwitchDto>()
                .RequireDestinationMemberSource(true);
            config.NewConfig<SwitchDto, SwitchDbEntity>()
                .RequireDestinationMemberSource(true);
            config.NewConfig<GetSwitchesListDto, SwitchesListDto>()
                .RequireDestinationMemberSource(true);
            config.NewConfig<SwitchDbEntity, SwitchLookupDto>()
                .RequireDestinationMemberSource(true);
        }
    }
}
