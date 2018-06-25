using System;
using NodaTime;

namespace BabySitter.Core
{
    public class NightlyChargeCalculator
    {
        public long Calculate(NightlyChargeParameters parameters)
        {
            if (IsArrivalTimeInvalid(parameters.ArrivalTime))
                throw new InvalidOperationException();

            var hours = parameters.LeaveTime - parameters.ArrivalTime;
            return hours.Hours * parameters.HourlyRate;
        }

        private static bool IsArrivalTimeInvalid(LocalTime arrivalTime)
        {
            return arrivalTime < new LocalTime(17, 0);
        }
    }
}