using Application.ACL.Switches.Queries.GetSwitchAcesList.Common;
using Application.ACL.Switches.Queries.GetSwitchAcesList.Filter;
using Application.Common.Query.List;
using FluentValidation;

namespace Application.ACL.Switches.Queries.GetSwitchAcesList.Query
{
    public class GetSwitchAcesListQueryValidator : CommonListQueryValidator<GetSwitchAcesListQuery, SwitchAceFilter, SwitchAceSortField>
    {
        public GetSwitchAcesListQueryValidator(AbstractValidator<SwitchAceFilter> filterValidator) : base(filterValidator)
        {
        }
    }
}
