namespace Application.SwitchHandling.Handler.Exceptions
{
    public class WrongSuperPassAppException : SwitchHandlerException
    {
        public WrongSuperPassAppException() { }

        public WrongSuperPassAppException(string message) : base(message) { }

        public WrongSuperPassAppException(string message, Exception innerException) : base(message, innerException) { }
    }
}
