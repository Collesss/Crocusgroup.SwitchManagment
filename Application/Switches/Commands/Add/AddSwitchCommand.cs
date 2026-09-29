using MediatR;

namespace Application.Switches.Commands.Add
{
    /// <summary>
    /// Command for add switch.
    /// </summary>
    public class AddSwitchCommand : IRequest<int>
    {
        /// <summary>
        /// Switch ip or hostname, cant be null, empty, contains only whitespace or be longer 100 char, unique.
        /// </summary>
        public string IpOrName { get; set; }

        /// <summary>
        /// Switch location, cant be longer 250 char.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Switch description, cant be longer 500 char.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Switch handler, cant be null, empty, contains only whitespace or be longer 100 char.
        /// </summary>
        public string Handler { get; set; }

        /// <summary>
        /// The login of a switch user who can configure ports and retrieve information about them and the VLANs, cant be null, empty, contains only whitespace or be longer 50 char.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// User password, cant be null, empty, contains only whitespace or be longer 150 char.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Switch super password, cant be empty, contains only whitespace or be longer 150 char, if not use set in null.
        /// </summary>
        public string SuperPassword { get; set; }
    }
}
