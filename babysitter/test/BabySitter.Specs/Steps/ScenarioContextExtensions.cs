using BabySitter.Specs.Support.Scenarios;
using NodaTime;

namespace BabySitter.Specs.Steps
{
    public static class ScenarioContextExtensions
    {
        public const string ArrivalTimeKey = "ArrivalTime";
        public const string HourlyRateKey = "HourlyRate";
        public const string HourlyRateBetweenBedtimeAndMidnightKey = "HourlyRateBetweenBedtimeAndMidnight";
        public const string BedtimeKey = "Bedtime";
        public const string ChargeAmountKey = "ChargeAmount";

        public static void ArrivalTime(this ScenarioContext context, LocalDateTime time)
        {
            context.Set(ArrivalTimeKey, time);
        }

        public static LocalDateTime ArrivalTime(this ScenarioContext context)
        {
            return context.Get<LocalDateTime>(ArrivalTimeKey);
        }

        public static void HourlyRate(this ScenarioContext context, long rate)
        {
            context.Set(HourlyRateKey, rate);
        }

        public static long HourlyRate(this ScenarioContext context)
        {
            return context.Get<long>(HourlyRateKey);
        }
        
        public static void HourlyRateBetweenBedtimeAndMidnight(this ScenarioContext context, long rate)
        {
            context.Set(HourlyRateBetweenBedtimeAndMidnightKey, rate);
        }

        public static long HourlyRateBetweenBedtimeAndMidnight(this ScenarioContext context)
        {
            return context.Get<long>(HourlyRateBetweenBedtimeAndMidnightKey);
        }

        public static void Bedtime(this ScenarioContext context, LocalDateTime time)
        {
            context.Set(BedtimeKey, time);
        }

        public static LocalDateTime Bedtime(this ScenarioContext context)
        {
            return context.Get<LocalDateTime>(BedtimeKey);
        }

        public static void ChargeAmount(this ScenarioContext context, long chargeAmount)
        {
            context.Set(ChargeAmountKey, chargeAmount);
        }

        public static long ChargeAmount(this ScenarioContext context)
        {
            return context.Get<long>(ChargeAmountKey);
        }
    }
}