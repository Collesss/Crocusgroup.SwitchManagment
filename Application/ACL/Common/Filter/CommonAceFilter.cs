namespace Application.ACL.Common.Filter
{
    public class CommonAceFilter
    {
        /// <summary>
        /// Filter By SwitchId, be great or equal than 1 or null.
        /// </summary>
        public int? SwitchId { get; set; }

        /// <summary>
        /// Filter by GroupId, cant be great than 100, apply if not null, empty or contains only whitespace.
        /// </summary>
        public string SearchByGroupId { get; set; }
    }
}
