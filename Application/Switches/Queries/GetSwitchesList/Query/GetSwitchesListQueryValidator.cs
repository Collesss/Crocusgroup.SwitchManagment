using Application.Common.Query.List;
using Application.Switches.Queries.GetSwitchesList.Common;
using Application.Switches.Queries.GetSwitchesList.Filter;
using FluentValidation;

namespace Application.Switches.Queries.GetSwitchesList.Query
{
    public class GetSwitchesListQueryValidator : CommonListQueryValidator<GetSwitchesListQuery, SwitchFilter, SwitchSortField>
    {
        public GetSwitchesListQueryValidator(AbstractValidator<SwitchFilter> filterValidator) : base(filterValidator)
        {
        }
    }
}
