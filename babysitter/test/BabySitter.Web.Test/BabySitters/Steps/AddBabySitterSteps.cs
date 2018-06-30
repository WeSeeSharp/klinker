using System.Linq;
using System.Threading.Tasks;
using BabySitter.Web.Test.General;
using Xunit;
using Xunit.Abstractions;
using Xunit.Gherkin.Steps;

namespace BabySitter.Web.Test.BabySitters.Steps
{
    public class AddBabySitterSteps
    {
        private readonly ITestOutputHelper _output;
        private readonly ServerFixture _fixture;

        public AddBabySitterSteps(ITestOutputHelper output, ServerFixture fixture)
        {
            _output = output;
            _fixture = fixture;
        }

        [Given("I have no baby sitters$")]
        public void GivenIHaveNoBabySitters()
        {
            _fixture.ClearDatabase();
        }

        [When("I add baby sitter (.*) (.*) with default rates$")]
        public async Task WhenIAddBabySitter(string firstName, string lastName)
        {
            await _fixture.AddBabySitter(firstName, lastName);
        }

        [When("I add baby sitter (.*) (.*) with rates (.*), (.*), and (.*)")]
        public async Task WhenIAddBabySitterWithRates(
            string firstName, 
            string lastName, 
            int standard,
            int betweenBedtimeAndMidnight, 
            int afterMidnight)
        {
            await _fixture.AddBabySitter(firstName, lastName, standard, betweenBedtimeAndMidnight, afterMidnight);
        }

        [Then("baby sitter (.*) (.*) should have default rates$")]
        public async Task ThenBabySitterShouldHaveDefaultRates(string firstName, string lastName)
        {
            var sitters = await _fixture.GetBabySitters();
            var sitter = sitters.Where(s => s.FirstName == firstName)
                .Single(s => s.LastName == lastName);

            Assert.Equal(12, sitter.HourlyRate);
            Assert.Equal(8, sitter.HourlyRateBetweenBedtimeAndMidnight);
            Assert.Equal(16, sitter.HourlyRateAfterMidnight);
        }

        [Then("baby sitter (.*) (.*) should have rates (.*), (.*), and (.*)$")]
        public async Task ThenBabySitterShouldHaveCustomRates(
            string firstName, 
            string lastName, 
            int standard,
            int betweenBedtimeAndMidnight, 
            int afterMidnight)
        {
            var sitters = await _fixture.GetBabySitters();
            var sitter = sitters.Where(s => s.FirstName == firstName)
                .Single(s => s.LastName == lastName);
            
            Assert.Equal(standard, sitter.HourlyRate);
            Assert.Equal(betweenBedtimeAndMidnight, sitter.HourlyRateBetweenBedtimeAndMidnight);
            Assert.Equal(afterMidnight, sitter.HourlyRateAfterMidnight);
        }
    }
}