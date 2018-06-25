﻿using System.Diagnostics;
using BabySitter.Specs.Support.Scenarios;
using NodaTime;

namespace BabySitter.Specs.Steps
{
    public static class ScenarioContextExtensions
    {
        public const string ArrivalTimeKey = "ArrivalTime";
        public const string HourlyRateKey = "HourlyRate";
        public const string BedtimeKey = "Bedtime";
        public const string ChargeAmountKey = "ChargeAmount";

        public static void ArrivalTime(this ScenarioContext context, LocalTime time)
        {
            context.Set(ArrivalTimeKey, time);
        }

        public static LocalTime ArrivalTime(this ScenarioContext context)
        {
            return context.Get<LocalTime>(ArrivalTimeKey);
        }

        public static void HourlyRate(this ScenarioContext context, int rate)
        {
            context.Set(HourlyRateKey, rate);
        }

        public static int HourlyRate(this ScenarioContext context)
        {
            return context.Get<int>(HourlyRateKey);
        }

        public static void Bedtime(this ScenarioContext context, LocalTime time)
        {
            context.Set(BedtimeKey, time);
        }

        public static LocalTime Bedtime(this ScenarioContext context)
        {
            return context.Get<LocalTime>(BedtimeKey);
        }

        public static void ChargeAmount(this ScenarioContext context, int chargeAmount)
        {
            context.Set(ChargeAmountKey, chargeAmount);
        }
        
        public static int ChargeAmount(this ScenarioContext context)
        {
            return context.Get<int>(ChargeAmountKey);
        }
    }
}