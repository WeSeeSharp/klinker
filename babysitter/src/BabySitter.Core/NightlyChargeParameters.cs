using System.ComponentModel;
using NodaTime;

namespace BabySitter.Core
{
    public class NightlyChargeParameters
    {
        public LocalDateTime ArrivalTime { get; }
        public LocalDateTime Bedtime { get; }
        public LocalDateTime LeaveTime { get; }
        public long HourlyRate { get; }
        public long HourlyRateBetweenBedtimeAndMidnight { get; }
        public long HourlyRateAfterMidnight { get; }

        public NightlyChargeParameters(LocalDateTime arrivalTime, LocalDateTime bedtime, LocalDateTime leaveTime, 
            long hourlyRate = 12,
            long hourlyRateBetweenBedtimeAndMidnight = 8,
            long hourlyRateAfterMidnight = 16)
        {
            ArrivalTime = arrivalTime.ToNearestHour(RoundingDirection.Down);
            Bedtime = bedtime.ToNearestHour(RoundingDirection.Up);
            LeaveTime = leaveTime.ToNearestHour(RoundingDirection.Up);
            HourlyRate = hourlyRate;
            HourlyRateBetweenBedtimeAndMidnight = hourlyRateBetweenBedtimeAndMidnight;
            HourlyRateAfterMidnight = hourlyRateAfterMidnight;
        }
    }
}