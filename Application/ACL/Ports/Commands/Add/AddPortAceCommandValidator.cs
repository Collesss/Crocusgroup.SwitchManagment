using Application.ACL.Common.Commands;
using Application.ACL.Ports.Common;
using FluentValidation;

namespace Application.ACL.Ports.Commands.Add
{
    public class AddPortAceCommandValidator : CommonAddAceCommandValidator<AddPortAceCommand, PortRightsMask>
    {
        public AddPortAceCommandValidator() 
        {
            RuleFor(addPortAceCommand => addPortAceCommand.InterfaceName)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
