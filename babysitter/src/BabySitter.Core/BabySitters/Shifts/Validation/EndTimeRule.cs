using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Shifts.Entities;
using BabySitter.Core.General.Validation;
using NodaTime;

namespace BabySitter.Core.BabySitters.Shifts.Validation
{
    public class EndTimeRule : ValidationRule<Shift, LocalDateTime?>
    {        
        public EndTimeRule() 
            : base(s => s.EndTime, "End time must be after start time")
        {
        }

        protected override Task<bool> IsValid(Shift model)
        {
            var isValid = model.EndTime == null
                          || model.EndTime.Value > model.StartTime;

            if (model.EndTime.HasValue 
                && !IsEndTimeBefore4AM(model.EndTime.Value, model.StartTime))
            {
                isValid = false;
            }
            
            return Task.FromResult(isValid);
        }

        private static bool IsEndTimeBefore4AM(LocalDateTime endTime, LocalDateTime startTime)
        {
            if (endTime.Date > startTime.Date)
                return endTime.Hour <= 4;

            return endTime.Date == startTime.Date;
        }
    }
}