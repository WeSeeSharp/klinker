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

        public HourlyRates Clone()
        {
            return FromRates(this);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((HourlyRates) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Standard.GetHashCode();
                hashCode = (hashCode * 397) ^ BetweenBedtimeAndMidnight.GetHashCode();
                hashCode = (hashCode * 397) ^ AfterMidnight.GetHashCode();
                return hashCode;
            }
        }

        protected bool Equals(HourlyRates other)
        {
            return Standard == other.Standard && BetweenBedtimeAndMidnight == other.BetweenBedtimeAndMidnight && AfterMidnight == other.AfterMidnight;
        }

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

        public static HourlyRates FromRates(HourlyRates rates)
        {
            return FromRates(rates.Standard, rates.BetweenBedtimeAndMidnight, rates.AfterMidnight);
        }
        
        public static bool operator ==(HourlyRates first, HourlyRates second)
        {
            if (first == null)
                return second == null;

            if (second == null)
                return false;

            return first.Standard == second.Standard
                   && first.BetweenBedtimeAndMidnight == second.BetweenBedtimeAndMidnight
                   && first.AfterMidnight == second.AfterMidnight;
        }

        public static bool operator !=(HourlyRates first, HourlyRates second)
        {
            return !(first == second);
        }
    }
}