namespace BabySitter.Core.BabySitters.Models
{
    public class SitterModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int HourlyRate { get; set; }
        public int HourlyRateAfterMidnight { get; set; }
        public int HourlyRateBetweenBedtimeAndMidnight { get; set; }
    }
}