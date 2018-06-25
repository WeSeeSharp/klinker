using NodaTime;

namespace BabySitter.Core
{
    public enum RoundingDirection
    {
        Up,
        Down
    }

    public static class LocalDateTimeExtensions
    {
        public static LocalDateTime ToNearestHour(this LocalDateTime dateTime, RoundingDirection direction)
        {
            if (dateTime.Minute == 0)
                return dateTime;


            return direction == RoundingDirection.Up
                ? dateTime.PlusMinutes(60 - dateTime.Minute)
                : dateTime.PlusMinutes(-dateTime.Minute);
        }
    }
}