using Application.Common.Exceptions;

namespace Application.SwitchHandling.Handler.Exceptions
{
    public class VLANNotExistAppException : AppException
    {
        public VLANNotExistAppException() { }

        public VLANNotExistAppException(string message) : base(message) { }

        public VLANNotExistAppException(string message, Exception innerException) : base(message, innerException) { }
    }
}
