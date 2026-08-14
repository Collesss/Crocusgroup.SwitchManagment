using Application.SwitchHandling.Handler.Exceptions.Enums;

namespace Application.SwitchHandling.Handler.Exceptions
{
    public class SwitchHandlerException : Exception
    {
        private static readonly Dictionary<SwitchHandlerErrorType, string> ErrorMessage = new() 
        {
            [SwitchHandlerErrorType.Unknown] = "Unknown",
            [SwitchHandlerErrorType.HostNotExistOrUnreac] = "HostNotExistOrUnreac",
            [SwitchHandlerErrorType.WrongLoginOrPass] = "WrongLoginOrPass",
            [SwitchHandlerErrorType.WrongSuperPass] = "WrongSuperPass",
            [SwitchHandlerErrorType.WrongInterface] = "WrongInterface",
            [SwitchHandlerErrorType.VLANNotExist] = "VLANNotExist"
        };

        public SwitchHandlerErrorType ErrorType { get; private set; }


        public SwitchHandlerException() { }

        public SwitchHandlerException(string message) : base(message) { }

        public SwitchHandlerException(string message, Exception innerException) : base(message, innerException) { }

        public SwitchHandlerException(SwitchHandlerErrorType errorType) : base(ErrorMessage[errorType])
        {
            ErrorType = errorType;
        }

        public SwitchHandlerException(SwitchHandlerErrorType errorType, Exception innerException) : base(ErrorMessage[errorType], innerException)
        {
            ErrorType = errorType;
        }
    }
}
