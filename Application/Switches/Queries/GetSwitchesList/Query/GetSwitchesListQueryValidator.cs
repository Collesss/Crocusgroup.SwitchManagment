using Application.Common.Query.List;
using Application.Switches.Queries.GetSwitchesList.Filter;
using Application.Switches.Queries.GetSwitchesList.Response;
using FluentValidation;

namespace Application.Switches.Queries.GetSwitchesList.Query
{
    public class GetSwitchesListQueryValidator(IValidator<SwitchFilter> filterValidator) : 
        CommonListQueryValidator<GetSwitchesListQuery, SwitchFilter, SwitchLookupDto>(filterValidator)
    {
        //protected override HashSet<string> AllowedSortFields => ["Id", "IpOrName", "Location", "Description", "Handler"];
    }
}
