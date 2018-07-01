using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabySitter.Core.General.Validation
{
    public interface IValidator<in T>
    {
        Task<ValidationResult> Validate(T model);
    }
    
    public abstract class Validator<T> : IValidator<T>
    {
        private readonly List<IValidationRule<T>> _rules;

        protected Validator()
        {
            _rules = new List<IValidationRule<T>>();
        }
        
        public async Task<ValidationResult> Validate(T model)
        {
            var errors = await Task.WhenAll(_rules.Select(r => r.Validate(model)));
            return new ValidationResult(errors.Where(e => e != null));
        }

        protected void AddRule(IValidationRule<T> rule)
        {
            _rules.Add(rule);
        }
    }
}