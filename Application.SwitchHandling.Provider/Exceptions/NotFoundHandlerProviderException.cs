namespace Application.SwitchHandling.Provider.Exceptions
{
    public class NotFoundHandlerProviderException : Exception
    {
        public NotFoundHandlerProviderException() : base() { }

        public NotFoundHandlerProviderException(string message) : base(message) { }

        public NotFoundHandlerProviderException(string message, Exception innerException) : base(message, innerException) { }
    }
}
