using Application.ACL.Vlans.Queries.GetVlanAcesList.Common;
using Application.ACL.Vlans.Queries.GetVlanAcesList.Filter;
using Application.Common.Query.List;
using FluentValidation;

namespace Application.ACL.Vlans.Queries.GetVlanAcesList.Query
{
    public class GetVlanAcesListQueryValidator(IValidator<VlanAceFilter> filterValidator) 
        : CommonListQueryValidator<GetVlanAcesListQuery, VlanAceFilter, VlanAceSortField>(filterValidator)
    {
    }
}
