namespace Application.Switches.Queries.GetSwitchesList.Filter
{
    /// <summary>
    /// Switch filter.
    /// </summary>
    public class SwitchFilter
    {
        /// <summary>
        /// Filter by IpOrName, cant be great than 100, apply if not null, empty or contains only whitespace.
        /// </summary>
        public string SearchByIpOrName { get; set; }

        /// <summary>
        /// Filter by Location, cant be great than 250, apply if not null, empty or contains only whitespace.
        /// </summary>
        public string SearchByLocation { get; set; }

        /// <summary>
        /// Filter by Description, cant be great than 500, apply if not null, empty or contains only whitespace.
        /// </summary>
        public string SearchByDescription { get; set; }

        /// <summary>
        /// Filter by Handler, cant be great than 100, apply if not null, empty or contains only whitespace.
        /// </summary>
        public string SearchByHandler { get; set; }
    }
}