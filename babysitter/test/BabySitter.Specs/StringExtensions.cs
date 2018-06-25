using System.Linq;
using NodaTime;

namespace BabySitter.Specs
{
    public static class StringExtensions
    {
        public static LocalTime ToLocalTime(this string time)
        {
            var parts = time.Split(':');
            parts[1] = parts[1].Split(' ')[0];

            var hours = int.Parse(parts[0]);
            if (time.ToLowerInvariant().Contains("pm"))
                hours += 12;
            
            var minutes = int.Parse(parts[1]);
            return new LocalTime(hours, minutes);
        }
    }
}