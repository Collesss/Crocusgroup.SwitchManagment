using Application.ACL.Vlans.Queries.GetVlanAcesList.Filter;
using Application.ACL.Vlans.Queries.GetVlanAcesList.Response;
using Application.Common.Query.List;
using FluentValidation;

namespace Application.ACL.Vlans.Queries.GetVlanAcesList.Query
{
    public class GetVlanAcesListQueryValidator(IValidator<VlanAceFilter> filterValidator) 
        : CommonListQueryValidator<GetVlanAcesListQuery, VlanAceFilter, VlanAceLookupDto>(filterValidator)
    {
    }
}
