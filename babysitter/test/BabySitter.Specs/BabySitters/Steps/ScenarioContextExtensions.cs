using BabySitter.Core.BabySitters.Models;
using Xunit.Gherkin.Scenarios;

namespace BabySitter.Specs.BabySitters.Steps
{
    public static class ScenarioContextExtensions
    {
        private const string BabySittersKey = "BabySittersKey";
        private const string TotalKey = "TotalKey";

        public static SitterModel[] BabySitters(this ScenarioContext context)
        {
            return context.Get<SitterModel[]>(BabySittersKey);
        }

        public static void BabySitters(this ScenarioContext context, SitterModel[] sitters)
        {
            context.Set(BabySittersKey, sitters);
        }

        public static TotalModel Total(this ScenarioContext context)
        {
            return context.Get<TotalModel>(TotalKey);
        }

        public static void Total(this ScenarioContext context, TotalModel model)
        {
            context.Set(TotalKey, model);
        }
    }
}