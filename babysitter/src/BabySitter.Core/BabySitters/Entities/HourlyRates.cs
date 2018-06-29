using System.ComponentModel.DataAnnotations;

namespace BabySitter.Core.BabySitters.Entities
{
    public class HourlyRates
    {
        public const int StandardHourlyRate = 12;
        public const int StandardHourlyRateBetweenBedtimeAndMidnight = 8;
        public const int StandardHourlyRateAfterMidnight = 16;

        [Required] public int Standard { get; set; } = StandardHourlyRate;

        [Required] public int BetweenBedtimeAndMidnight { get; set; } = StandardHourlyRateBetweenBedtimeAndMidnight;

        [Required] public int AfterMidnight { get; set; } = StandardHourlyRateAfterMidnight;

        public static HourlyRates FromRates(int standard, int betweenBedtimeAndMidnight, int afterMidnight)
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