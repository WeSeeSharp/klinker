using System;
using BabySitter.Core.BabySitters.Shifts.Entities;
using BabySitter.Core.BabySitters.Shifts.Validation;
using BabySitter.Core.General.Validation;
using NodaTime;

namespace BabySitter.Core.BabySitters
{
    public class NightlyChargeCalculator
    {
        private readonly IValidator<Shift> _validator;

        public NightlyChargeCalculator()
        {
            _validator = new ShiftValidator();
        }
        
        public long Calculate(NightlyChargeParameters parameters)
        {
            var shift = parameters.ToShift();
            var result = _validator.Validate(shift).Result;
            if (result.Invalid)
                throw new InvalidOperationException();
            
            return GetNormalCharge(parameters)
                   + GetBedtimeToMidnightCharge(parameters)
                   + GetAfterMidnightCharge(parameters);
        }

        private static long GetNormalCharge(NightlyChargeParameters parameters)
        {
            var hours = parameters.LeaveTime < parameters.Bedtime
                ? (parameters.LeaveTime - parameters.StartTime).Hours
                : (parameters.Bedtime - parameters.StartTime).Hours;

            return hours * parameters.HourlyRate;
        }

        private static long GetBedtimeToMidnightCharge(NightlyChargeParameters parameters)
        {
            var midnight = GetMidnight(parameters.StartTime);

            long hours = 0;
            if (parameters.LeaveTime > midnight)
                hours = (midnight - parameters.Bedtime).Hours;

            else if (parameters.LeaveTime > parameters.Bedtime)
                hours = (parameters.LeaveTime - parameters.Bedtime).Hours;

            return hours * parameters.HourlyRateBetweenBedtimeAndMidnight;
        }

        private static long GetAfterMidnightCharge(NightlyChargeParameters parameters)
        {
            var midnight = GetMidnight(parameters.StartTime);

            if (parameters.LeaveTime < midnight)
                return 0;

            return parameters.LeaveTime.Hour * parameters.HourlyRateAfterMidnight;
        }

        private static LocalDateTime GetMidnight(LocalDateTime arrivalTime)
        {
            return arrivalTime
                .Date
                .PlusDays(1)
                .AtMidnight();
        }
    }
}