using Application.ACL.Switches.Queries.GetSwitchAcesList.Filter;
using Application.ACL.Switches.Queries.GetSwitchAcesList.Response;
using Application.Common.Query.List;
using FluentValidation;

namespace Application.ACL.Switches.Queries.GetSwitchAcesList.Query
{
    public class GetSwitchAcesListQueryValidator(IValidator<SwitchAceFilter> filterValidator) : 
        CommonListQueryValidator<GetSwitchAcesListQuery, SwitchAceFilter, SwitchAceLookupDto>(filterValidator)
    {
    }
}
