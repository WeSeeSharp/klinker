using System.Linq;
using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Entities;
using BabySitter.Core.BabySitters.Shifts.Entities;
using BabySitter.Core.General.Validation;

namespace BabySitter.Core.BabySitters.Shifts.Validation
{
    public class ActiveShiftLimitRule : ValidationRule<Shift, Sitter>
    {
        public ActiveShiftLimitRule() 
            : base(s => s.Sitter, "Sitter already has an active shift.")
        {
        }

        protected override Task<bool> IsValid(Shift model)
        {
            var sitterShifts = model.GetShiftsForSitter();
            var activeShifts = sitterShifts.Count(s => s.EndTime == null);
            return Task.FromResult(activeShifts < 1);
        }
    }
}