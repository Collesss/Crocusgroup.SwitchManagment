namespace Application.SwitchHandling.Handler.Exceptions
{
    public class WrongSuperPassSwitchHandlerException : SwitchHandlerException
    {
        public WrongSuperPassSwitchHandlerException() { }

        public WrongSuperPassSwitchHandlerException(string message) : base(message) { }

        public WrongSuperPassSwitchHandlerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
