using System;
using BabySitter.Core.BabySitters.Entities;
using BabySitter.Core.BabySitters.Shifts.Entities;
using NodaTime;

namespace BabySitter.Core.Test.Utilties
{
    public class ModelFactory
    {
        public static Sitter CreateSitter(
            string firstName = null,
            string lastName = null,
            HourlyRates rates = null)
        {
            return new Sitter
            {
                FirstName = firstName ?? Guid.NewGuid().ToString(),
                LastName = lastName ?? Guid.NewGuid().ToString(),
                HourlyRates = rates ?? HourlyRates.FromStandardRates()
            };
        }

        public static Shift CreateShift(
            Sitter sitter = null,
            LocalDateTime? startTime = null,
            LocalDateTime? bedtime = null,
            LocalDateTime? endtime = null,
            HourlyRates hourlyRates = null)
        {
            return new Shift
            {
                Bedtime = bedtime ?? new LocalDateTime(2018, 6, 30, 21, 0),
                EndTime = endtime ?? new LocalDateTime(2018, 7, 1, 0, 0),
                HourlyRates = hourlyRates ?? HourlyRates.FromStandardRates(),
                Sitter = sitter ?? CreateSitter(),
                StartTime = startTime ?? new LocalDateTime(2018, 6, 30, 17, 0)
            };
        }
    }
}