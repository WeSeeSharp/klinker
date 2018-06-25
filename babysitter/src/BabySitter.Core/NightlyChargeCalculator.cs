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

            if (IsLeaveTimeInvalid(parameters.ArrivalTime, parameters.LeaveTime))
                throw new InvalidOperationException();
            
            var normalCharge = GetNormalCharge(parameters);
            var bedtimeToMidnightCharge = GetBedtimeToMidnightCharge(parameters);
            var afterMidnightCharge = GetAfterMidnightCharge(parameters);
            return normalCharge 
                   + bedtimeToMidnightCharge
                   + afterMidnightCharge;
        }

        private static bool IsLeaveTimeInvalid(LocalDateTime arrivalTime, LocalDateTime leaveTime)
        {
            var totalTime = leaveTime - arrivalTime;
            return totalTime.Hours >= 11
                   && totalTime.Minutes >= 0;
        }

        private static bool IsArrivalTimeInvalid(LocalDateTime arrivalTime)
        {
            return arrivalTime.Hour < 17;
        }

        private static long GetNormalCharge(NightlyChargeParameters parameters)
        {
            var hours = parameters.LeaveTime < parameters.Bedtime
                ? (parameters.LeaveTime - parameters.ArrivalTime).Hours
                : (parameters.Bedtime - parameters.ArrivalTime).Hours;
            
            return hours * parameters.HourlyRate;
        }

        private static long GetBedtimeToMidnightCharge(NightlyChargeParameters parameters)
        {
            var midnight = GetMidnight(parameters.ArrivalTime);
            var leaveTime = parameters.LeaveTime;
            var bedTime = parameters.Bedtime;

            long hours = 0;
            if (leaveTime > midnight)
                hours = (midnight - bedTime).Hours;
            else if (leaveTime > bedTime)
                hours = (leaveTime - bedTime).Hours;
            
            return hours * parameters.HourlyRateBetweenBedtimeAndMidnight;
        }

        private static long GetAfterMidnightCharge(NightlyChargeParameters parameters)
        {
            var midnight = GetMidnight(parameters.ArrivalTime);

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