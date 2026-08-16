using MediatR;

namespace Application.UseCases.Switches.Queries.GetSwitchDetail
{
    public class AdminGetSwitchDetailQuery : IRequest<AdminGetSwitchDetailVm>
    {
        public int Id { get; set; }
    }
}
