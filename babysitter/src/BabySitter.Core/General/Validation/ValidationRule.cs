using System.Threading.Tasks;

namespace BabySitter.Core.General.Validation
{
    public interface IValidationRule<in T>
    {
        Task<ValidationError> Validate(T model);
    }
}