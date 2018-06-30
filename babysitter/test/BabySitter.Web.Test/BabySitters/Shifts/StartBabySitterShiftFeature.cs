using System.Threading.Tasks;
using BabySitter.Web.Test.General;
using Xunit;
using Xunit.Abstractions;
using Xunit.Gherkin.Features;
using Xunit.Gherkin.Scenarios;

namespace BabySitter.Web.Test.BabySitters.Shifts
{
    [Collection(ServerFixtureCollection.Name)]
    public class StartBabySitterShiftFeature : Feature
    {

        public StartBabySitterShiftFeature(ITestOutputHelper output, ServerFixture fixture)
            : base(output, fixture)
        {
        }
        
        [Fact]
        [Scenario("Start baby sitter shift")]
        public async Task ShouldCreateShiftForSitter()
        {
            await Given("I have no baby sitters");
            await Given("I add baby sitter John Doe with default rates");
            await When("baby sitter John Doe starts at 5:00 PM with a bedtime of 9:00 PM");
            await Then("I should see baby sitter John Doe with a shift starting at 5:00 PM with a bedtime of 9:00 PM");
        }
    }
}