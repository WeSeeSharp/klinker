using System;

namespace BabySitter.Core.General.Validation
{
    public class ValidationException : Exception
    {
        public ValidationResult Result { get; }

        public ValidationException(ValidationResult result)
        {
            Result = result;
        }
    }
}