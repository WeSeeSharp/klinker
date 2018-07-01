using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Shifts.Entities;
using BabySitter.Core.General.Validation;
using NodaTime;

namespace BabySitter.Core.BabySitters.Shifts.Validation
{
    public class StartTimeRule : ValidationRule<Shift, LocalDateTime>
    {
        public StartTimeRule() 
            : base(s => s.StartTime, "Start time must be on or after 5:00 PM")
        {
        }

        protected override Task<bool> IsValid(Shift model)
        {
            return Task.FromResult(model.StartTime.Hour >= 17);
        }
    }
}