using System;
using NodaTime;

namespace BabySitter.Core
{
    public static class StringExtensions
    {
        public static LocalDateTime ToLocalDateTime(this string time)
        {
            var parts = time.Split(':');
            parts[1] = parts[1].Split(' ')[0];

            var hours = int.Parse(parts[0]);
            if (time.ToLowerInvariant().Contains("pm"))
                hours += 12;
            else if (hours == 12)
                hours = 0;

            var minutes = int.Parse(parts[1]);
            return new LocalTime(hours, minutes)
                .On(LocalDate.FromDateTime(DateTime.Today));
        }
    }
}