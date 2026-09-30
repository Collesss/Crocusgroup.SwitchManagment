using Application.Common.Query.List;
using FluentValidation;

namespace Application.Switches.Queries.GetSwitchesList
{
    public class GetSwitchesListQueryValidator : CommonListQueryValidator<GetSwitchesListQuery, SwitchFilter, SwitchSortField>
    {
        public GetSwitchesListQueryValidator() 
        {
            //RuleFor(getSwitchesListQueryValidator => getSwitchesListQueryValidator.Filter);
        }
    }
}
