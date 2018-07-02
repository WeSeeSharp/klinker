using System.Threading.Tasks;
using BabySitter.Specs.General;
using Xunit;
using Xunit.Abstractions;
using Xunit.Gherkin.Features;
using Xunit.Gherkin.Scenarios;

namespace BabySitter.Specs.BabySitters.Shifts
{
    [Collection(ServerFixtureCollection.Name)]
    public class EndBabySitterShiftFeature : Feature
    {
        public EndBabySitterShiftFeature(ITestOutputHelper output, ServerFixture fixture)
            : base(output, fixture)
        {
        }

        [Fact]
        [Scenario("End baby sitter shift")]
        public async Task ShouldUpdateSitterShiftWithEndDate()
        {
            await Given("I have no baby sitters");
            await Given("I add baby sitter Bob Jack with default rates");
            await Given("baby sitter Bob Jack starts at 5:00 PM with a bedtime of 9:00 PM");
            await When("baby sitter Bob Jack leaves at 10:00 PM");
            await Then("I should see baby sitter Bob Jack left at 10:00 PM");
        }
    }
}