using Application.ACL.Switches.Commands.Common;
using MediatR;

namespace Application.ACL.Switches.Commands.Add
{
    /// <summary>
    /// Command for add switch ace, adding the record must be unique based on a composite key consisting of the fields: SwitchId and GroupId.
    /// </summary>
    public class AddSwitchAceCommand : IRequest<int>
    {
        /// <summary>
        /// Switch id, cant be less than 1.
        /// </summary>
        public int SwitchId { get; set; }

        /// <summary>
        /// Group id, cant be null empty, contains only whitespace or be length great or equal than 150.
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// Access right mask.
        /// </summary>
        public SwitchRightsMask RightsMask { get; set; }
    }
}
