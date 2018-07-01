using BabySitter.Core.BabySitters.Entities;
using BabySitter.Core.BabySitters.Shifts.Entities;
using NodaTime;

namespace BabySitter.Core.BabySitters
{
    public class NightlyChargeParameters
    {
        public LocalDateTime StartTime { get; }
        public LocalDateTime Bedtime { get; }
        public LocalDateTime LeaveTime { get; }
        public long HourlyRate { get; }
        public long HourlyRateBetweenBedtimeAndMidnight { get; }
        public long HourlyRateAfterMidnight { get; }

        public NightlyChargeParameters(
            LocalDateTime startTime, 
            LocalDateTime bedtime, 
            LocalDateTime leaveTime,
            long hourlyRate = 12,
            long hourlyRateBetweenBedtimeAndMidnight = 8,
            long hourlyRateAfterMidnight = 16)
        {
            StartTime = startTime.ToNearestHour(RoundingDirection.Down);
            Bedtime = bedtime.ToNearestHour(RoundingDirection.Up);
            LeaveTime = leaveTime.ToNearestHour(RoundingDirection.Up);
            HourlyRate = hourlyRate;
            HourlyRateBetweenBedtimeAndMidnight = hourlyRateBetweenBedtimeAndMidnight;
            HourlyRateAfterMidnight = hourlyRateAfterMidnight;
        }

        public Shift ToShift()
        {
            return new Shift
            {
                Bedtime = Bedtime,
                EndTime = LeaveTime,
                StartTime = StartTime,
                HourlyRates = HourlyRates.FromRates(HourlyRate, HourlyRateBetweenBedtimeAndMidnight, HourlyRateAfterMidnight)
            };
        }
    }
}