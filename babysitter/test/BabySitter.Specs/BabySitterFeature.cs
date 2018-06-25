using System.Threading.Tasks;
using BabySitter.Specs.Support.Features;
using BabySitter.Specs.Support.Scenarios;
using Xunit;
using Xunit.Abstractions;

namespace BabySitter.Specs
{
    public class BabySitterFeature : Feature
    {
        public BabySitterFeature(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Scenario("Baby sitter arrives at 5:00 PM and leaves before bedtime")]
        public async Task SitterLeavesAtBedtime()
        {
            await Given("I arrive at 5:00 PM");
            await Given("I charge $12 per hour");
            await Given("bedtime is 9:00 PM");
            await When("I leave at bedtime");
            await Then("I should charge $48");
        }
        
        [Fact]
        [Scenario("Baby sitter leaves at midnight")]
        public async Task SiterLeavesAtMidnight()
        {
            await Given("I arrive at 5:00 PM");
            await Given("I charge $12 per hour");
            await Given("bedtime is 9:00 PM");
            await Given("I charge $8 per hour between bedtime and midnight");
            await When("I leave at midnight");
            await Then("I should charge $72");
        }
    }
}