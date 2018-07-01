namespace BabySitter.Core.BabySitters.Models
{
    public class SitterModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long HourlyRate { get; set; }
        public long HourlyRateAfterMidnight { get; set; }
        public long HourlyRateBetweenBedtimeAndMidnight { get; set; }
    }
}