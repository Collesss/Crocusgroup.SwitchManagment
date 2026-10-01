using Application.ACL.Common.Filter;
using FluentValidation;

namespace Application.ACL.Vlans.Queries.GetVlanAcesList.Filter
{
    public class VlanAceFilterValidator : CommonAceFilterValidator<VlanAceFilter>
    {
        public VlanAceFilterValidator() 
        {
            RuleFor(vlanAceFilter => vlanAceFilter.VlanId)
                .GreaterThan(1);
        }
    }
}
