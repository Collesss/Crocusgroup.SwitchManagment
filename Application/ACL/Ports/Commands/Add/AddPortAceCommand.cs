using Application.ACL.Common.Commands;
using Application.ACL.Ports.Common;
using MediatR;

namespace Application.ACL.Ports.Commands.Add
{
    /// <summary>
    /// Command for add port ace, adding the record must be unique based on a composite key consisting of the fields: SwitchId, GroupId and InterfaceName.
    /// </summary>
    public class AddPortAceCommand : CommonAddAceCommand<PortRightsMask>, IRequest<int>
    {
        /// <summary>
        /// Interface name, cant be null, empty, contains only whitespace or be longer 100 char.
        /// </summary>
        public string InterfaceName { get; set; }
    }
}
