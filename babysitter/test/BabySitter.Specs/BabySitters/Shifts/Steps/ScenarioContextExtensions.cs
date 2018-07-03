using BabySitter.Core.BabySitters.Shifts.Models;
using Xunit.Gherkin.Scenarios;

namespace BabySitter.Specs.BabySitters.Shifts.Steps
{
    public static class ScenarioContextExtensions
    {
        private const string BabySitterShiftsKey = "BabySitterShiftsKey";
        private const string EndedShiftIdKey = "EndedShiftIdKey";

        public static ShiftModel[] BabySitterShifts(this ScenarioContext context)
        {
            return context.Get<ShiftModel[]>(BabySitterShiftsKey);
        }

        public static void BabySitterShifts(this ScenarioContext context, ShiftModel[] models)
        {
            context.Set(BabySitterShiftsKey, models);
        }

        public static int EndedShiftId(this ScenarioContext context)
        {
            return context.Get<int>(EndedShiftIdKey);
        }

        public static void EndedShiftId(this ScenarioContext context, int shiftId)
        {
            context.Set(EndedShiftIdKey, shiftId);
        }
    }
}