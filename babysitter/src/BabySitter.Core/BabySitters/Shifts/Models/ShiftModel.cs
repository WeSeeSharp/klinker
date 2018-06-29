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
        public int HourlyRate { get; set; }
        public int HourlyRateBetweenBedtimeAndMidnight { get; set; }
        public int HourlyRateAfterMidnight { get; set; }
    }
}