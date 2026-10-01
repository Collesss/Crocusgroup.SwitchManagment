using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Common.Exceptions
{
    public class ValidationAppException : AppException
    {
        public Dictionary<string, string[]> Errors { get; private set; } = [];

        public ValidationAppException() { }
        
        public ValidationAppException(Dictionary<string, string[]> errors) 
        {
            Errors = errors;
        }

        public ValidationAppException(string message) : base(message) { }

        public ValidationAppException(string message, Dictionary<string, string[]> errors) : base(message) 
        {
            Errors = errors;
        }

        public ValidationAppException(string message, Exception innerException) : base(message, innerException) { }

        public ValidationAppException(string message, Exception innerException, Dictionary<string, string[]> errors) : base(message, innerException) 
        {
            Errors = errors;
        }
    }
}