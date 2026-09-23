using MediatR;

namespace Application.ACL.Ports.Commands.Delete
{
    /// <summary>
    /// Command for delete port ace.
    /// </summary>
    public class DeletePortAceCommand : IRequest
    {
        /// <summary>
        /// Id deleting port ace, cant be less 1.
        /// </summary>
        public int Id { get; set; }
    }
}
