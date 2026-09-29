using FluentValidation;

namespace Application.Common.Commands.Delete
{
    public class CommonDeleteCommandValidator<T> : AbstractValidator<T>
        where T : CommonDeleteCommand
    {
        public CommonDeleteCommandValidator() 
        {
            RuleFor(deleteCommand => deleteCommand.Id)
                .GreaterThan(0);
        }
    }
}
