using Application.ACL.Common;
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
        /// Interface name, cant be null, empty or contains only whitespaces.
        /// </summary>
        public string InterfaceName { get; set; }
    }
}
