namespace Application.SwitchHandling.Handler.Exceptions
{
    public class VLANNotExistSwitchHandlerException : SwitchHandlerException
    {
        public VLANNotExistSwitchHandlerException() { }

        public VLANNotExistSwitchHandlerException(string message) : base(message) { }

        public VLANNotExistSwitchHandlerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
