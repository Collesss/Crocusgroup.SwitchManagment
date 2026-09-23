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
            public static class Port
            {
                public const string List = "acl.port.list";
                public const string View = "acl.port.view";
                public const string Add = "acl.port.add";
                public const string Delete = "acl.port.delete";
                public const string Update = "acl.port.update";
            }

            public static class Vlan
            {
                public const string List = "acl.vlan.list";
                public const string View = "acl.vlan.view";
                public const string Add = "acl.vlan.add";
                public const string Delete = "acl.vlan.delete";
                public const string Update = "acl.vlan.update";
            }
            public static class VlanOnPort
            {
                public const string List = "acl.vlanOnPort.list";
                public const string View = "acl.vlanOnPort.view";
                public const string Add = "acl.vlanOnPort.add";
                public const string Delete = "acl.vlanOnPort.delete";
                public const string Update = "acl.vlanOnPort.update";
            }
        }

        private static IEnumerable<string> GetAllDefinedPermissions(Type type) =>
            type.GetFields(BindingFlags.Static | BindingFlags.Public)
                .Where(field => !field.IsInitOnly && field.IsLiteral && field.FieldType == typeof(string))
                .Select(field => field.GetValue(null).ToString())
                .Concat(type.GetNestedTypes().SelectMany(GetAllDefinedPermissions));
    }
}