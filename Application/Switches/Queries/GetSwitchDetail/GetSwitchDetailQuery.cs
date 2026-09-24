using MediatR;

namespace Application.Switches.Queries.GetSwitchDetail
{
    /// <summary>
    /// Query for get switch by Id.
    /// </summary>
    public class GetSwitchDetailQuery : IRequest<SwitchDetailResponse>
    {
        /// <summary>
        /// Switch Id, cant be less 1
        /// </summary>
        public int Id { get; set; }
    }
}
