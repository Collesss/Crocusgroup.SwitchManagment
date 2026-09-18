namespace Application.CurrentUserService.Security
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class RequirePermissionAttribute : Attribute
    {
        public string Premission { get; }

        public RequirePermissionAttribute(string permission) 
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(permission);

            Premission = permission;
        }
    }
}
