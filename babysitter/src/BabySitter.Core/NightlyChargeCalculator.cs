using System;
using NodaTime;

namespace BabySitter.Core
{
    public class NightlyChargeCalculator
    {
        public int Calculate(NightlyChargeParameters parameters)
        {
            if (IsArrivalTimeInvalid(parameters.ArrivalTime))
                throw new InvalidOperationException();
            throw new System.NotImplementedException();
        }

        private bool IsArrivalTimeInvalid(LocalTime arrivalTime)
        {
            return arrivalTime < new LocalTime(17, 0);
        }
    }
}