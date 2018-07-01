using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BabySitter.Core.General.Validation
{
    public interface IValidationRule<in T>
    {
        Task<ValidationError> Validate(T model);
    }

    public abstract class ValidationRule<T, TProperty> : IValidationRule<T>
    {
        private readonly Expression<Func<T, TProperty>> _property;
        private readonly string _message;

        protected ValidationRule(Expression<Func<T, TProperty>> property, string message)
        {
            _property = property;
            _message = message;
        }

        public async Task<ValidationError> Validate(T model)
        {
            return await IsValid(model)
                ? null
                : new ValidationError(_property.GetPropertyName(), _message);
        }

        protected abstract Task<bool> IsValid(T model);
    }
}