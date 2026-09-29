using Application.ACL.Common.Commands;
using Application.ACL.Vlans.Common;
using FluentValidation;

namespace Application.ACL.Vlans.Commands.Add
{
    public class AddVlanAceCommandValidator : CommonAddAceCommandValidator<AddVlanAceCommand, VlanRigthsMask>
    {
        public AddVlanAceCommandValidator() 
        {
            RuleFor(addVlanAceCommand => addVlanAceCommand.VlanId)
                .LessThan(1)
                .GreaterThan(4094);
        }
    }
}
