using System.Threading.Tasks;
using BabySitter.Web.Test.General;
using Xunit;
using Xunit.Abstractions;
using Xunit.Gherkin.Scenarios;
using Xunit.Gherkin.Steps;

namespace BabySitter.Web.Test.BabySitters.Shifts.Steps
{
    public class GetBabySitterShiftsSteps
    {
        private readonly ITestOutputHelper _output;
        private readonly ServerFixture _fixture;

        public GetBabySitterShiftsSteps(ITestOutputHelper output, ServerFixture fixture)
        {
            _output = output;
            _fixture = fixture;
        }

        [When("I get shifts for baby sitter (.*) (.*)$")]
        public async Task WhenIGetShiftsForBabySitter(string firstName, string lastName)
        {
            var sitters = await _fixture.GetBabySitters();
            var sitter = sitters.FindByName(firstName, lastName);
            var shifts = await _fixture.GetBabySitterShifts(sitter.Id);
            ScenarioContext.Current.BabySitterShifts(shifts);
        }

        [Then("I should see (.*) shifts for baby sitter (.*) (.*)$")]
        public void ThenIShouldSeeShiftsForBabySitter(int count, string firstName, string lastName)
        {
            var shifts = ScenarioContext.Current.BabySitterShifts();
            Assert.Equal(count, shifts.Length);
        }
    }
}