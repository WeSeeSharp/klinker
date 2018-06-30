using BabySitter.Core.BabySitters.Models;
using Xunit.Gherkin.Scenarios;

namespace BabySitter.Web.Test.BabySitters.Steps
{
    public static class ScenarioContextExtensions
    {
        private const string BabySittersKey = "BabySittersKey";

        public static SitterModel[] BabySitters(this ScenarioContext context)
        {
            return context.Get<SitterModel[]>(BabySittersKey);
        }

        public static void BabySitters(this ScenarioContext context, SitterModel[] sitters)
        {
            context.Set(BabySittersKey, sitters);
        }
    }
}