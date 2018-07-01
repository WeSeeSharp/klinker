using System.Collections.Generic;
using System.Linq;

namespace BabySitter.Core.General.Validation
{
    public class ValidationResult
    {
        public bool Invalid => Errors.Any();
        
        public ValidationError[] Errors { get; }

        public ValidationResult(IEnumerable<ValidationError> errors)
        {
            Errors = (errors ?? Enumerable.Empty<ValidationError>()).ToArray();
        }
    }
}