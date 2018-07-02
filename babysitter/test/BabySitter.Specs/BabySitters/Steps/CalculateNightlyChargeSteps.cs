using System.Threading.Tasks;
using BabySitter.Core;
using BabySitter.Specs.General;
using Xunit;
using Xunit.Abstractions;
using Xunit.Gherkin.Scenarios;
using Xunit.Gherkin.Steps;

namespace BabySitter.Specs.BabySitters.Steps
{
    public class CalculateNightlyChargeSteps
    {
        private readonly ITestOutputHelper _output;
        private readonly ServerFixture _fixture;

        public CalculateNightlyChargeSteps(ITestOutputHelper output, ServerFixture fixture)
        {
            _output = output;
            _fixture = fixture;
        }

        [When("I calculate the nightly charge starting at (.*) with bedtime at (.*) and leaving at (.*)$")]
        public async Task WhenICalculateNightlyCharge(
            string startTime, 
            string bedtime, 
            string leaveTime)
        {
            var startDateTime = startTime.ToLocalDateTime();
            var bedDateTime = bedtime.ToLocalDateTime();
            var leaveDateTime = leaveTime.ToLowerInvariant().Contains("am")
                ? leaveTime.ToLocalDateTime().PlusDays(1)
                : leaveTime.ToLocalDateTime();

            var total = await _fixture.CalculateNightlyCharge(startDateTime, bedDateTime, leaveDateTime);
            ScenarioContext.Current.Total(total);
        }

        [Then("I should see a total of \\$(.*)$")]
        public void ThenIShouldSeeATotalOf(long total)
        {
            var model = ScenarioContext.Current.Total();
            Assert.Equal(total, model.Total);
        }
    }
}