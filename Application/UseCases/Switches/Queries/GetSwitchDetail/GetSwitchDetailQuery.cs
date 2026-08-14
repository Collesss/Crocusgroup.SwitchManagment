using MediatR;

namespace Application.UseCases.Switches.Queries.GetSwitchDetail
{
    public class GetSwitchDetailQuery : IRequest<GetSwitchDetailVm>
    {
        public int Id { get; set; }
    }
}
