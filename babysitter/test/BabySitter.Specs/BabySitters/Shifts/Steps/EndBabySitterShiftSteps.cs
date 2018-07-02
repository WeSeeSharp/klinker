using System.Linq;
using System.Threading.Tasks;
using BabySitter.Core;
using BabySitter.Specs.General;
using Xunit;
using Xunit.Abstractions;
using Xunit.Gherkin.Steps;

namespace BabySitter.Specs.BabySitters.Shifts.Steps
{
    public class EndBabySitterShiftSteps
    {
        private readonly ITestOutputHelper _output;
        private readonly ServerFixture _fixture;

        public EndBabySitterShiftSteps(ITestOutputHelper output, ServerFixture fixture)
        {
            _output = output;
            _fixture = fixture;
        }

        [Given("baby sitter (.*) (.*) starts at (.*) with a bedtime of (.*)$")]
        [When("baby sitter (.*) (.*) starts at (.*) with a bedtime of (.*)$")]
        public async Task BabySitterStartsWithBedtime(
            string firstName,
            string lastName,
            string startTime,
            string bedtime)
        {
            var sitters = await _fixture.GetBabySitters();
            var sitter = sitters.FindByName(firstName, lastName);

            var startDateTime = startTime.ToLocalDateTime();
            var bedtimeDateTime = bedtime.ToLocalDateTime();
            await _fixture.StartShift(sitter.Id, startDateTime, bedtimeDateTime);
        }

        [Given("baby sitter (.*) (.*) leaves at (.*)$")]
        [When("baby sitter (.*) (.*) leaves at (.*)$")]
        public async Task WhenBabySitterLeaves(string firstName, string lastName, string endTime)
        {
            var sitters = await _fixture.GetBabySitters();
            var sitter = sitters.FindByName(firstName, lastName);

            var shifts = await _fixture.GetBabySitterShifts(sitter.Id);
            var currentShift = shifts.Single(s => s.EndTime == null);
            
            var endDateTime = endTime.ToLowerInvariant().Contains("am") 
                ? endTime.ToLocalDateTime().PlusDays(1)
                : endTime.ToLocalDateTime();
            
            await _fixture.EndShift(sitter.Id, currentShift.Id, endDateTime);
        }

        [Then("I should see baby sitter (.*) (.*) left at (.*)$")]
        public async Task ThenIShouldSeeBabySitterLeftAt(string firstName, string lastName, string endTime)
        {
            var sitters = await _fixture.GetBabySitters();
            var sitter = sitters.FindByName(firstName, lastName);

            var shifts = await _fixture.GetBabySitterShifts(sitter.Id);
            var endDateTime = endTime.ToLocalDateTime();

            Assert.True(shifts.Any(s => s.EndTime == endDateTime));
        }
    }
}