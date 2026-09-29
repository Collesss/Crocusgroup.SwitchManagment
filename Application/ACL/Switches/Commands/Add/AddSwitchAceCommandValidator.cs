using Application.ACL.Common.Commands;
using Application.ACL.Switches.Common;

namespace Application.ACL.Switches.Commands.Add
{
    public class AddSwitchAceCommandValidator : CommonAddAceCommandValidator<AddSwitchAceCommand, SwitchRightsMask>
    {
    }
}
