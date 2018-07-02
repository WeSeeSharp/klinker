using System.Threading.Tasks;
using BabySitter.Specs.General;
using Xunit;
using Xunit.Abstractions;
using Xunit.Gherkin.Features;
using Xunit.Gherkin.Scenarios;

namespace BabySitter.Specs.BabySitters
{
    [Collection(ServerFixtureCollection.Name)]
    public class AddBabySitterFeature : Feature
    {
        public AddBabySitterFeature(ITestOutputHelper output, ServerFixture fixture)
            : base(output, fixture)
        {
        }
        
        [Fact]
        [Scenario("Add baby sitter with standard rates")]
        public async Task ShouldAddBabySitterWithStandardRates()
        {
            await Given("I have no baby sitters");
            await When("I add baby sitter Jack Jill with default rates");
            await Then("baby sitter Jack Jill should have default rates");
        }
        
        [Fact]
        [Scenario("Add baby sitter with custom rates")]
        public async Task ShouldAddBabySitterWithCustomRates()
        {
            await Given("I have no baby sitters");
            await When("I add baby sitter John Joe with rates 15, 12, and 20");
            await Then("baby sitter John Joe should have rates 15, 12, and 20");
        }
    }
}