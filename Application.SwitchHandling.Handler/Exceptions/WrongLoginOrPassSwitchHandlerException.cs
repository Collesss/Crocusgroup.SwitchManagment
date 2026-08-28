namespace Application.SwitchHandling.Handler.Exceptions
{
    public class WrongLoginOrPassSwitchHandlerException : SwitchHandlerException
    {
        public WrongLoginOrPassSwitchHandlerException() { }

        public WrongLoginOrPassSwitchHandlerException(string message) : base(message) { }

        public WrongLoginOrPassSwitchHandlerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
