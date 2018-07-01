using System;
using System.Linq.Expressions;
using System.Reflection;

namespace BabySitter.Core
{
    public static class ExpressionExtensions
    {
        public static string GetPropertyName<TSource, TProperty>(this Expression<Func<TSource, TProperty>> expression)
        {
            if (!(expression.Body is MemberExpression memberExpression))
                throw new ArgumentException(nameof(expression));

            var property = memberExpression.Member as PropertyInfo;
            if (property == null)
                throw new ArgumentException(nameof(expression));
            return property.Name;
        }
    }
}