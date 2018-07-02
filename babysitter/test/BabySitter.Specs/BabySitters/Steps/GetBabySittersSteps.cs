using System.Threading.Tasks;
using BabySitter.Specs.General;
using Xunit;
using Xunit.Abstractions;
using Xunit.Gherkin.Scenarios;
using Xunit.Gherkin.Steps;

namespace BabySitter.Specs.BabySitters.Steps
{
    public class GetBabySittersSteps
    {
        private readonly ITestOutputHelper _output;
        private readonly ServerFixture _fixture;

        public GetBabySittersSteps(ITestOutputHelper output, ServerFixture fixture)
        {
            _output = output;
            _fixture = fixture;
        }

        [When("I get baby sitters$")]
        public async Task WhenIGetBabySitters()
        {
            var sitters = await _fixture.GetBabySitters();
            ScenarioContext.Current.BabySitters(sitters);
        }

        [Then("I should see (.*) baby sitters$")]
        public void ThenIShouldSeeBabySitters(int count)
        {
            var sitters = ScenarioContext.Current.BabySitters();
            Assert.Equal(count, sitters.Length);
        }
    }
}