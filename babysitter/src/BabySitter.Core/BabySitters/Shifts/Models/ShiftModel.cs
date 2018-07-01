using NodaTime;

namespace BabySitter.Core.BabySitters.Shifts.Models
{
    public class ShiftModel
    {
        public int Id { get; set; }
        public int SitterId { get; set; }
        public LocalDateTime StartTime { get; set; }
        public LocalDateTime Bedtime { get; set; }
        public LocalDateTime? EndTime { get; set; }
        public long HourlyRate { get; set; }
        public long HourlyRateBetweenBedtimeAndMidnight { get; set; }
        public long HourlyRateAfterMidnight { get; set; }
    }
}