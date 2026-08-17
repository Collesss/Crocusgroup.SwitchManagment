using MediatR;

namespace Application.Switches.Queries.GetSwitchDetail
{
    public class AdminGetSwitchDetailQuery : IRequest<AdminSwitchDetailVm>
    {
        public int Id { get; set; }
    }
}
