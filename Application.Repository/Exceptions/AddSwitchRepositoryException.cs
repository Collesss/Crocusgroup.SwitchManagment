using Application.Repository.Exceptions.Enums;

namespace Application.Repository.Exceptions
{
    public class AddSwitchRepositoryException : SwitchRepositoryException
    {
        public AddSwitchRepositoryErrorCode ErrorCode { get; private set; }

        public AddSwitchRepositoryException() { }

        public AddSwitchRepositoryException(AddSwitchRepositoryErrorCode errorCode) : base(GetMessage(errorCode))
        {
            ErrorCode = errorCode;
        }

        public AddSwitchRepositoryException(AddSwitchRepositoryErrorCode errorCode, Exception innerException) : base(GetMessage(errorCode), innerException)
        {
            ErrorCode = errorCode;
        }

        public AddSwitchRepositoryException(string message) : base(message) { }

        public AddSwitchRepositoryException(string message, AddSwitchRepositoryErrorCode errorCode) : base(message) 
        {
            ErrorCode = errorCode;
        }

        public AddSwitchRepositoryException(string message, Exception innerException) : base(message, innerException) { }

        public AddSwitchRepositoryException(string message, Exception innerException, AddSwitchRepositoryErrorCode errorCode) : base(message, innerException) 
        {
            ErrorCode = errorCode;
        }

        private static string GetMessage(AddSwitchRepositoryErrorCode errorCode) =>
            errorCode switch 
            {
                AddSwitchRepositoryErrorCode.IpOrHostAlreadyExist => "An error occurred while adding the entity Switch. Switch with this ip or hostname already exist.",
                _ => "Unknown error."
            };
    }
}
