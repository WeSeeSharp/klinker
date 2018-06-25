using NodaTime;

namespace BabySitter.Core
{
    public class NightlyChargeParameters
    {
        public LocalTime ArrivalTime { get; }
        public LocalTime Bedtime { get; }
        public LocalTime LeaveTime { get; }
        public int HourlyRate { get; }

        public NightlyChargeParameters(LocalTime arrivalTime, LocalTime bedtime, LocalTime leaveTime, int hourlyRate)
        {
            ArrivalTime = arrivalTime;
            Bedtime = bedtime;
            LeaveTime = leaveTime;
            HourlyRate = hourlyRate;
        }
    }
}