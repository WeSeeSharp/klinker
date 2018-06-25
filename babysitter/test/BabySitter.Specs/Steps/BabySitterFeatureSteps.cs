using BabySitter.Core;
using BabySitter.Specs.Support.Scenarios;
using BabySitter.Specs.Support.Steps;
using Xunit;

namespace BabySitter.Specs.Steps
{
    public class BabySitterFeatureSteps
    {
        [Given("I arrive at (.*)")]
        public void GivenIArriveAt(string time)
        {
            ScenarioContext.Current.ArrivalTime(time.ToLocalTime());
        }

        [Given("I charge \\$(\\d*) per hour")]
        public void GivenICharge(int hourlyRate)
        {
            ScenarioContext.Current.HourlyRate(hourlyRate);
        }

        [Given("bedtime is (.*)")]
        public void GivenBedtimeIs(string bedtime)
        {
            ScenarioContext.Current.Bedtime(bedtime.ToLocalTime());
        }

        [When("I leave at bedtime")]
        public void WhenILeaveAtBedtime()
        {
            var parameters = new NightlyChargeParameters(
                ScenarioContext.Current.ArrivalTime(),
                ScenarioContext.Current.Bedtime(),
                ScenarioContext.Current.Bedtime(),
                ScenarioContext.Current.HourlyRate());
            var calculator = new NightlyChargeCalculator();
            var chargeAmount = calculator.Calculate(parameters);
            ScenarioContext.Current.ChargeAmount(chargeAmount);
        }

        [Then("I should charge \\$(\\d*)")]
        public void ThenIShouldBePaid(int chargeAmount)
        {
            var actual = ScenarioContext.Current.ChargeAmount();
            Assert.Equal(chargeAmount, actual);
        }
    }
}