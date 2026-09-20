namespace Application.Switches.Queries.GetSwitchesList
{
    /// <summary>
    /// Switch filter.
    /// </summary>
    public class SwitchFilter
    {
        /// <summary>
        /// Filter by IpOrName, cant be great than 100.
        /// </summary>
        public string SearchByIpOrName { get; set; }

        /// <summary>
        /// Filter by Location, cant be great than 250.
        /// </summary>
        public string SearchByLocation { get; set; }

        /// <summary>
        /// Filter by Description, cant be great than 500.
        /// </summary>
        public string SearchByDescription { get; set; }

        /// <summary>
        /// Filter by Handler, cant be great than 50.
        /// </summary>
        public string SearchByHandler { get; set; }
    }
}