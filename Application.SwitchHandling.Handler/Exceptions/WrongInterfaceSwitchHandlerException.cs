namespace Application.SwitchHandling.Handler.Exceptions
{
    public class WrongInterfaceSwitchHandlerException : SwitchHandlerException
    {
        public WrongInterfaceSwitchHandlerException() { }

        public WrongInterfaceSwitchHandlerException(string message) : base(message) { }

        public WrongInterfaceSwitchHandlerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
