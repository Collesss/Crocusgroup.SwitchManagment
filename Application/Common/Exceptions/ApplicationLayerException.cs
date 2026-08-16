using Application.Common.Exceptions.Enums;

namespace Application.Common.Exceptions
{
    public class ApplicationLayerException : Exception
    {
        public ApplicationErrorCode ErrorCode { get; private set; }

        public ApplicationLayerException() { }

        public ApplicationLayerException(ApplicationErrorCode errorCode) 
        {
            ErrorCode = errorCode;
        }


        public ApplicationLayerException(string message) : base(message) { }

        public ApplicationLayerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
