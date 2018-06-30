using System.Linq;
using System.Threading.Tasks;
using BabySitter.Core;
using BabySitter.Web.Test.General;
using Xunit;
using Xunit.Abstractions;
using Xunit.Gherkin.Steps;

namespace BabySitter.Web.Test.BabySitters.Shifts.Steps
{
    public class StartBabySitterShiftSteps
    {
        private readonly ITestOutputHelper _output;
        private readonly ServerFixture _fixture;

        public StartBabySitterShiftSteps(ITestOutputHelper output, ServerFixture fixture)
        {
            _output = output;
            _fixture = fixture;
        }

        [Then("I should see baby sitter (.*) (.*) with a shift starting at (.*) with a bedtime of (.*)$")]
        public async Task IShouldSeeBabySitterWithShiftStartingAtWithABedtimeOf(
            string firstName,
            string lastName,
            string startTime,
            string bedtime)
        {
            var sitters = await _fixture.GetBabySitters();
            var sitter = sitters.FindByName(firstName, lastName);

            var shifts = await _fixture.GetBabySitterShifts(sitter.Id);
            var currentShift = shifts.Single(s => s.EndTime == null);

            Assert.Equal(startTime.ToLocalDateTime(), currentShift.StartTime);
            Assert.Equal(bedtime.ToLocalDateTime(), currentShift.Bedtime);
        }
    }
}