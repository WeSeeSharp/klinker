using System.Net;
using System.Threading.Tasks;
using BabySitter.Core;
using BabySitter.Core.BabySitters;
using BabySitter.Web.Test.General;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;
using Xunit.Gherkin.Features;

namespace BabySitter.Web.Test.BabySitters
{
    [Collection(ServerFixtureCollection.Name)]
    public class CalculateNightlyChargeFeature : Feature
    {
        public CalculateNightlyChargeFeature(ITestOutputHelper output, ServerFixture fixture)
            : base(output, fixture)
        {
        }
        
        [Fact]
        public async Task ShouldReturnTotalChargeAmount()
        {
            await Given("I have no baby sitters");
            await When("I calculate the nightly charge starting at 5:00 PM with bedtime at 9:00 PM and leaving at 12:00 AM");
            await Then("I should see a total of $72");
        }
    }
}