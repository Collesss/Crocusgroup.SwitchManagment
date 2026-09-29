using FluentValidation;

namespace Application.ACL.Common.Commands
{
    public class CommonAddAceCommandValidator<T, TRights> : AbstractValidator<T>
        where T : CommonAddAceCommand<TRights>
        where TRights : Enum
    {
        public CommonAddAceCommandValidator() 
        {
            RuleFor(addAceCommand => addAceCommand.SwitchId)
                .GreaterThan(0);

            RuleFor(addAceCommand => addAceCommand.GroupId)
                .NotEmpty()
                .MaximumLength(150);
        }
    }
}
