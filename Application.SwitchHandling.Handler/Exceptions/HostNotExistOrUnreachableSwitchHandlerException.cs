namespace Application.SwitchHandling.Handler.Exceptions
{
    public class HostNotExistOrUnreachableSwitchHandlerException : SwitchHandlerException
    {
        public HostNotExistOrUnreachableSwitchHandlerException() { }

        public HostNotExistOrUnreachableSwitchHandlerException(string message) : base(message) { }

        public HostNotExistOrUnreachableSwitchHandlerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
