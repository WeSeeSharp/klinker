using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BabySitter.Core.General.Validation
{
    public class PropertyRequiredRule<TModel, TProperty> : IValidationRule<TModel>
        where TProperty : class
    {
        private readonly Expression<Func<TModel, TProperty>> _property;
        private readonly string _message;

        public PropertyRequiredRule(Expression<Func<TModel, TProperty>> property, string message)
        {
            _property = property;
            _message = message;
        }

        public Task<ValidationError> Validate(TModel model)
        {
            var error = HasValue(model)
                ? null
                : new ValidationError(_property.GetPropertyName(), _message);
            return Task.FromResult(error);
        }

        private bool HasValue(TModel model)
        {
            var value = _property.Compile()(model);
            if (value == null)
                return false;

            var stringValue = value as string;
            if (stringValue != null)
                return !string.IsNullOrWhiteSpace(stringValue);

            return true;
        }
    }
}