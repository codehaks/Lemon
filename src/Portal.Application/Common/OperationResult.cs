using System;

namespace Portal.Domain
{
    public class OperationResult
    {
        public bool Success { get; private set; }
        public Exception Exception { get; private set; }
        public string ErrorMessage { get; private set; }

        public static OperationResult BuildSuccess()
        {
            return new OperationResult { Success = true };
        }

        public static OperationResult BuildFailure(string errorMessage)
        {
            return new OperationResult { Success = false, ErrorMessage = errorMessage };
        }

        internal static OperationResult BuildFailure(Exception exception)
        {
            return new OperationResult
            {
                Success = false,
                Exception = exception,
                ErrorMessage = exception.Message
            };
        }
    }


}
