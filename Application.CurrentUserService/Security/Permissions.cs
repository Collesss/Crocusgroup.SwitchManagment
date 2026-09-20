using System.Reflection;

namespace Application.CurrentUserService.Security
{
    public static class Permissions
    {
        public static IReadOnlyCollection<string> AllDefinedPermissions { get; }

        static Permissions()
        {
            AllDefinedPermissions = GetAllDefinedPermissions(typeof(Permissions))
                .ToArray()
                .AsReadOnly();
        }

        public static class Switch
        {
            public const string List        = "switch.list";
            public const string View        = "switch.view";
            public const string Add         = "switch.add";
            public const string Delete      = "switch.delete";
            public const string Update      = "switch.update";
            public const string AclBypass   = "switch.acl_bypass";
        }

        public static class ACL
        {
            public static class Switch
            {
                public const string List    = "acl.switch.list";
                public const string View    = "acl.switch.view";
                public const string Add     = "acl.switch.add";
                public const string Delete  = "acl.switch.delete";
                public const string Update  = "acl.switch.update";
            }
        }

        private static IEnumerable<string> GetAllDefinedPermissions(Type type) =>
            type.GetFields(BindingFlags.Static | BindingFlags.Public)
                .Where(field => !field.IsInitOnly && field.IsLiteral && field.FieldType == typeof(string))
                .Select(field => field.GetValue(null).ToString())
                .Concat(type.GetNestedTypes().SelectMany(GetAllDefinedPermissions));
    }
}