using Application.ACL.Common;
using Application.ACL.Switches.Common;
using MediatR;

namespace Application.ACL.Switches.Commands.Add
{
    /// <summary>
    /// Command for add switch ace, adding the record must be unique based on a composite key consisting of the fields: SwitchId and GroupId.
    /// </summary>
    public class AddSwitchAceCommand : CommonAddAceCommand<SwitchRightsMask>, IRequest<int>
    {
    }
}
