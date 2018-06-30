using System.Linq;
using System.Threading.Tasks;
using BabySitter.Web.Test.General;
using Xunit.Abstractions;
using Xunit.Gherkin.Steps;

namespace BabySitter.Web.Test.BabySitters.Steps
{
    public class UpdateBabySitterSteps
    {
        private readonly ITestOutputHelper _output;
        private readonly ServerFixture _fixture;

        public UpdateBabySitterSteps(ITestOutputHelper output, ServerFixture fixture)
        {
            _output = output;
            _fixture = fixture;
        }

        [When("I update baby sitter (.*) (.*) to have rates (.*), (.*), and (.*)$")]
        public async Task WhenIUpdateBabySitter(
            string firstName,
            string lastName,
            int standard,
            int betweenBedtimeAndMidnight,
            int afterMidnight)
        {
            var sitters = await _fixture.GetBabySitters();
            var sitter = sitters.Where(s => s.FirstName == firstName)
                .Single(s => s.LastName == lastName);

            await _fixture.UpdateBabySitter(
                sitter.Id, 
                firstName, 
                lastName, 
                standard, 
                betweenBedtimeAndMidnight,
                afterMidnight);
        }
    }
}