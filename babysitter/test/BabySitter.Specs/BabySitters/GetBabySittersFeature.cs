using System.Threading.Tasks;
using BabySitter.Specs.General;
using Xunit;
using Xunit.Abstractions;
using Xunit.Gherkin.Features;
using Xunit.Gherkin.Scenarios;

namespace BabySitter.Specs.BabySitters
{
    [Collection(ServerFixtureCollection.Name)]
    public class GetBabySittersFeature : Feature
    {

        public GetBabySittersFeature(ITestOutputHelper output, ServerFixture fixture)
            : base(output, fixture)
        {
        }

        [Fact]
        [Scenario("Get all baby sitters")]
        public async Task ShouldGetAllBabySitters()
        {
            await Given("I have no baby sitters");
            await Given("I add baby sitter one two with default rates");
            await Given("I add baby sitter three four with default rates");
            await Given("I add baby sitter Jack Jill with default rates");
            await When("I get baby sitters");
            await Then("I should see 3 baby sitters");
        }
    }
}