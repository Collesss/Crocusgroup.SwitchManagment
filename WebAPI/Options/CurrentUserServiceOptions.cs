namespace WebAPI.Options
{
    public class CurrentUserServiceOptions : List<CurrentUserServiceOptions.Role>
    {
        public class Role
        {
            public string RoleName { get; set; }

            public string[] GroupsSIDs {  get; set; }

            public string[] Permissions { get; set; }
        }
    }
}
