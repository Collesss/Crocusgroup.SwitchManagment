using MediatR;

namespace Application.ACL.Switches.Commands.Delete
{
    /// <summary>
    /// Command for delete switch ace.
    /// </summary>
    public class DeleteSwitchAceCommand : IRequest
    {
        /// <summary>
        /// Id deleting switch ace, cant be less 1.
        /// </summary>
        public int Id { get; set; }
    }
}
