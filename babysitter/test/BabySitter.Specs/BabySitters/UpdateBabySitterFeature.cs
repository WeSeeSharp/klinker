using System.Threading.Tasks;
using BabySitter.Specs.General;
using Xunit;
using Xunit.Abstractions;
using Xunit.Gherkin.Features;
using Xunit.Gherkin.Scenarios;

namespace BabySitter.Specs.BabySitters
{
    [Collection(ServerFixtureCollection.Name)]
    public class UpdateBabySitterFeature : Feature
    {
        public UpdateBabySitterFeature(ITestOutputHelper output, ServerFixture fixture)
            : base(output, fixture)
        {
        }
        
        [Fact]
        [Scenario("Update baby sitter rates")]
        public async Task ShouldUpdateBabySitterRates()
        {
            await Given("I have no baby sitters");
            await Given("I add baby sitter 515 Jack with default rates");
            await When("I update baby sitter 515 Jack to have rates 50, 20, and 90");
            await Then("baby sitter 515 Jack should have rates 50, 20, and 90");
        }
    }
}