using System;
using BabySitter.Core.BabySitters.Shifts.Entities;
using BabySitter.Core.BabySitters.Shifts.Validation;
using BabySitter.Core.General.Validation;

namespace BabySitter.Core.BabySitters.Shifts.Services
{
    public class NightlyChargeCalculator
    {
        private readonly IValidator<Shift> _validator;

        public NightlyChargeCalculator()
        {
            _validator = new ShiftValidator();
        }
        
        public long Calculate(NightlyChargeArgs args)
        {
            var shift = args.ToShift();
            var result = _validator.Validate(shift).Result;
            if (result.Invalid)
                throw new InvalidOperationException();

            return shift.CalculateCharge().Value;
        }
    }
}