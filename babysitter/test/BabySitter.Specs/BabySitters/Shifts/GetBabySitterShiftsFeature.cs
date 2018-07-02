using System.Threading.Tasks;
using BabySitter.Specs.General;
using Xunit;
using Xunit.Abstractions;
using Xunit.Gherkin.Features;
using Xunit.Gherkin.Scenarios;

namespace BabySitter.Specs.BabySitters.Shifts
{
    [Collection(ServerFixtureCollection.Name)]
    public class GetBabySitterShiftsFeature : Feature
    {

        public GetBabySitterShiftsFeature(ITestOutputHelper output, ServerFixture fixture)
            : base(output, fixture)
        {
        }

        [Fact]
        [Scenario("Get shifts for baby sitter")]
        public async Task ShouldReturnAllShiftsForBabySitter()
        {
            await Given("I have no baby sitters");
            await Given("I add baby sitter one two with default rates");
            await Given("baby sitter one two starts at 5:00 PM with a bedtime of 9:00 PM");
            await Given("baby sitter one two leaves at 12:00 AM");
            await Given("baby sitter one two starts at 5:00 PM with a bedtime of 9:00 PM");
            await Given("baby sitter one two leaves at 12:00 AM");
            await Given("baby sitter one two starts at 5:00 PM with a bedtime of 9:00 PM");
            await When("I get shifts for baby sitter one two");
            await Then("I should see 3 shifts for baby sitter one two");
        }
    }
}