using Application.ACL.Ports.Queries.GetPortAcesList.Filter;
using Application.ACL.Ports.Queries.GetPortAcesList.Response;
using Application.Common.Query.List;
using FluentValidation;

namespace Application.ACL.Ports.Queries.GetPortAcesList.Query
{
    public class GetPortAcesListQueryValidator(IValidator<PortAceFilter> filterValidator) 
        : CommonListQueryValidator<GetPortAcesListQuery, PortAceFilter, PortAceLookupDto>(filterValidator)
    {
    }
}
