using Application.ACL.Ports.Queries.GetPortAcesList.Common;
using Application.ACL.Ports.Queries.GetPortAcesList.Filter;
using Application.Common.Query.List;
using FluentValidation;

namespace Application.ACL.Ports.Queries.GetPortAcesList.Query
{
    public class GetPortAcesListQueryValidator(IValidator<PortAceFilter> filterValidator) 
        : CommonListQueryValidator<GetPortAcesListQuery, PortAceFilter, PortAceSortField>(filterValidator)
    {
    }
}
