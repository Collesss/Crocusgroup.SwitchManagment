namespace Application.Common.Exceptions
{
    public class HandlerNotFoundAppException : NotFoundAppException
    {
        public HandlerNotFoundAppException() { }

        public HandlerNotFoundAppException(string message) : base(message) { }

        public HandlerNotFoundAppException(string message, Exception innerException) : base(message, innerException) { }
    }
}
