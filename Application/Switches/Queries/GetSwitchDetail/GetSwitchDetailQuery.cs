using MediatR;

namespace Application.Switches.Queries.GetSwitchDetail
{
    public class GetSwitchDetailQuery : IRequest<SwitchDetailResponse>
    {
        public int Id { get; set; }
    }
}
