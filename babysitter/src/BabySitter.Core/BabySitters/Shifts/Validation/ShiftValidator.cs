using BabySitter.Core.BabySitters.Entities;
using BabySitter.Core.BabySitters.Shifts.Entities;
using BabySitter.Core.General.Validation;

namespace BabySitter.Core.BabySitters.Shifts.Validation
{
    public class ShiftValidator : Validator<Shift>
    {
        public ShiftValidator()
        {
            AddRule(new EndTimeRule());
            AddRule(new StartTimeRule());
            AddRule(new ActiveShiftLimitRule());
            AddRule(new PropertyRequiredRule<Shift, HourlyRates>(s => s.HourlyRates, "Hourly rates are required"));
        }
    }
}