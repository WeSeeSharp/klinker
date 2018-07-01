using System.Collections.Generic;
using System.Linq;

namespace BabySitter.Core.General.Validation
{
    public class ValidationError
    {
        public string PropertyName { get; }
        public string[] Messages { get; }

        public ValidationError(string property, string message)
            : this(property, new []{message})
        {
            
        }
        
        public ValidationError(string propertyName, IEnumerable<string> messages)
        {
            PropertyName = propertyName;
            Messages = (messages ?? Enumerable.Empty<string>()).ToArray();
        }
    }
}