using MediatR;

namespace Application.Switches.Commands.Delete
{
    /// <summary>
    /// Command for remove switch.
    /// </summary>
    public class DeleteSwitchCommand : IRequest
    {
        /// <summary>
        /// Id removed switch, cant be less 1.
        /// </summary>
        public int Id { get; set; }
    }
}
