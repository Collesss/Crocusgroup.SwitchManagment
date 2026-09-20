using MediatR;

namespace Application.Switches.Queries.GetSwitchDetail
{
    public class GetSwitchDetailQuery : IRequest<SwitchDetailVm>
    {
        public int Id { get; set; }
    }
}
