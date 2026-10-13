using System.ComponentModel.DataAnnotations;
using System.Reflection;
using WebAPI.Models.Dto.Common.Request;

namespace WebAPI.ValidationAttributes
{
    public class GetListValidationAttribute<TFilter, TSortFieldEntity> : ValidationAttribute
        where TFilter : class, new()
        where TSortFieldEntity : class
    {
        
        public GetListValidationAttribute() 
        {
            ErrorMessage = "Sort field invalid.";
        }

        public override bool IsValid(object value)
        {
            if (value is not GetListEntityRequest<TFilter> getListRequest)
                throw new InvalidOperationException("This validation atrribute can apply only to GetListEntityRequest<>.");

            HashSet<string> props = new(typeof(TSortFieldEntity).GetProperties(BindingFlags.Public | BindingFlags.GetProperty).Select(prop => prop.Name));

            return string.IsNullOrEmpty(getListRequest.SortField) || props.Contains(getListRequest.SortField);
        }
    }
}
