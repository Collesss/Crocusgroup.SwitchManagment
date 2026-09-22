namespace Application.ACL.Common
{
    /// <summary>
    /// Common command for add ace.
    /// </summary>
    /// <typeparam name="T">Right mask.</typeparam>
    public abstract class CommonAddAceCommand<T>
        where T : Enum
    {
        /// <summary>
        /// Switch id, cant be less than 1.
        /// </summary>
        public int SwitchId { get; set; }

        /// <summary>
        /// Group id, cant be null empty, contains only whitespace or be length great or equal than 150.
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// Access right mask.
        /// </summary>
        public T RightsMask { get; set; }
    }
}
