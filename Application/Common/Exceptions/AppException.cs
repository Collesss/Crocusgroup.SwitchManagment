using Application.Common.Exceptions.Enums;

namespace Application.Common.Exceptions
{
    public class AppException : Exception
    {
        public AppErrorCode ErrorCode { get; private set; }

        public AppException() { }

        public AppException(AppErrorCode errorCode) 
        {
            ErrorCode = errorCode;
        }

        public AppException(AppErrorCode errorCode, Exception innerException) 
        {
            ErrorCode = errorCode;
        }

        public AppException(string message) : base(message) { }

        public AppException(string message, Exception innerException) : base(message, innerException) { }

        private static string GetMessage(AppErrorCode errorCode) =>
            errorCode switch
            {
                AppErrorCode.AdminAddSwitchAlreadyExist => "Switch with this name already exist.",
                _ => "Unknow error."
            };
    }
}
