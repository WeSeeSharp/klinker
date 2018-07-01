using System.ComponentModel.DataAnnotations;

namespace BabySitter.Core.BabySitters.Entities
{
    public class HourlyRates
    {
        public const long StandardHourlyRate = 12;
        public const long StandardHourlyRateBetweenBedtimeAndMidnight = 8;
        public const long StandardHourlyRateAfterMidnight = 16;

        [Required] public long Standard { get; set; } = StandardHourlyRate;

        [Required] public long BetweenBedtimeAndMidnight { get; set; } = StandardHourlyRateBetweenBedtimeAndMidnight;

        [Required] public long AfterMidnight { get; set; } = StandardHourlyRateAfterMidnight;

        public static HourlyRates FromStandardRates()
        {
            return FromRates(
                StandardHourlyRate, 
                StandardHourlyRateBetweenBedtimeAndMidnight,
                StandardHourlyRateAfterMidnight);
        }
        
        public static HourlyRates FromRates(long standard, long betweenBedtimeAndMidnight, long afterMidnight)
        {
            return new HourlyRates
            {
                Standard = standard,
                BetweenBedtimeAndMidnight = betweenBedtimeAndMidnight,
                AfterMidnight = afterMidnight
            };
        }
    }
}