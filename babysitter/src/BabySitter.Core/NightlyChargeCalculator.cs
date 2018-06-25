using System;
using NodaTime;

namespace BabySitter.Core
{
    public class NightlyChargeCalculator
    {
        private const int EarliestStartTime = 17;
        private const int MaximumNumberOfHours = 11;

        public long Calculate(NightlyChargeParameters parameters)
        {
            if (IsStartTimeInvalid(parameters.StartTime))
                throw new InvalidOperationException();

            if (IsLeaveTimeInvalid(parameters.StartTime, parameters.LeaveTime))
                throw new InvalidOperationException();

            return GetNormalCharge(parameters)
                   + GetBedtimeToMidnightCharge(parameters)
                   + GetAfterMidnightCharge(parameters);
        }

        private static bool IsLeaveTimeInvalid(LocalDateTime arrivalTime, LocalDateTime leaveTime)
        {
            var totalTime = leaveTime - arrivalTime;
            return totalTime.Hours >= MaximumNumberOfHours;
        }

        private static bool IsStartTimeInvalid(LocalDateTime arrivalTime)
        {
            return arrivalTime.Hour < EarliestStartTime;
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