using MediatR;

namespace Application.Switches.Commands.Add
{
    /// <summary>
    /// Command for add switch.
    /// </summary>
    public class AddSwitchCommand : IRequest<int>
    {
        /// <summary>
        /// Switch ip or hostname, be uniq, cant be null empty or contains only whitespaces and length great than 100.
        /// </summary>
        public string IpOrName { get; set; }

        /// <summary>
        /// Switch location, length cant be great than 250.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Switch description, length cant be great than 500.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Switch handler, length cant be great than 50.
        /// </summary>
        public string Handler { get; set; }

        /// <summary>
        /// Switch user login can be get info about ports and vlans switch and setup ports, length cant be great than 50.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Switch user password for Login, length cant be great than 100.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Switch super password, length cant be great than 100.
        /// </summary>
        public string SuperPassword { get; set; }
    }
}
