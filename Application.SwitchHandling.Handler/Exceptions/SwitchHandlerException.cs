using Application.SwitchHandling.Handler.Exceptions.Enums;

namespace Application.SwitchHandling.Handler.Exceptions
{
    public class SwitchHandlerException : Exception
    {
        public SwitchHandlerErrorType ErrorType { get; private set; }


        public SwitchHandlerException() { }

        public SwitchHandlerException(string message) : base(message) { }

        public SwitchHandlerException(string message, Exception innerException) : base(message, innerException) { }

        public SwitchHandlerException(SwitchHandlerErrorType errorType) : base(GetErrorMessage(errorType))
        {
            ErrorType = errorType;
        }

        public SwitchHandlerException(SwitchHandlerErrorType errorType, Exception innerException) : base(GetErrorMessage(errorType), innerException)
        {
            ErrorType = errorType;
        }

        private static string GetErrorMessage(SwitchHandlerErrorType errorType) =>
            errorType switch
            {
                SwitchHandlerErrorType.HostNotExistOrUnreac => "HostNotExistOrUnreac",
                SwitchHandlerErrorType.WrongLoginOrPass => "WrongLoginOrPass",
                SwitchHandlerErrorType.WrongSuperPass => "WrongSuperPass",
                SwitchHandlerErrorType.WrongInterface => "WrongInterface",
                SwitchHandlerErrorType.VLANNotExist => "VLANNotExist",
                _ => "Unknown",
            };
    }
}
