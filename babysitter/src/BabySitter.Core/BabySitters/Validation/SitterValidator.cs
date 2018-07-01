using BabySitter.Core.BabySitters.Entities;
using BabySitter.Core.General.Validation;

namespace BabySitter.Core.BabySitters.Validation
{
    public class SitterValidator : Validator<Sitter>
    {
        public SitterValidator()
        {
            AddRule(new PropertyRequiredRule<Sitter, string>(s => s.FirstName, "First name is required"));
            AddRule(new PropertyRequiredRule<Sitter, string>(s => s.LastName, "Last name is required"));
            AddRule(new PropertyRequiredRule<Sitter, HourlyRates>(s => s.HourlyRates, "Hourly rates are required"));
        }
    }
}