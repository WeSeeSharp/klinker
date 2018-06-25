using BabySitter.Core;
using BabySitter.Specs.Support.Scenarios;
using BabySitter.Specs.Support.Steps;
using NodaTime;
using Xunit;

namespace BabySitter.Specs.Steps
{
    public class BabySitterFeatureSteps
    {
        [Given("I arrive at (.*)$")]
        public void GivenIArriveAt(string time)
        {
            ScenarioContext.Current.ArrivalTime(time.ToLocalDateTime());
        }

        [Given("I charge \\$(\\d*) per hour$")]
        public void GivenICharge(long hourlyRate)
        {
            ScenarioContext.Current.HourlyRate(hourlyRate);
        }

        [Given("bedtime is (.*)$")]
        public void GivenBedtimeIs(string bedtime)
        {
            ScenarioContext.Current.Bedtime(bedtime.ToLocalDateTime());
        }

        [Given("I charge \\$(\\d*) per hour between bedtime and midnight$")]
        public void GivenIChargeAmountPerHourBetweenBedtimeAndMidnight(long hourlyRate)
        {
            ScenarioContext.Current.HourlyRateBetweenBedtimeAndMidnight(hourlyRate);
        }

        [Given("I charge \\$(\\d*) per hour after midnight$")]
        public void GivenIChargeAmountPerHourAfterMidnight(long hourlyRate)
        {
            ScenarioContext.Current.HourlyRateAfterMidnight(hourlyRate);
        }
        
        [When("I leave at bedtime$")]
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

        [When("I leave at midnight$")]
        public void WhenILeaveAtMidnight()
        {
            var midnight = ScenarioContext.Current.ArrivalTime()
                .PlusDays(1)
                .Date;
            var parameters = new NightlyChargeParameters(
                ScenarioContext.Current.ArrivalTime(),
                ScenarioContext.Current.Bedtime(),
                midnight.AtMidnight(),
                ScenarioContext.Current.HourlyRate(),
                ScenarioContext.Current.HourlyRateBetweenBedtimeAndMidnight());
            
            var calculator = new NightlyChargeCalculator();
            var chargeAmount = calculator.Calculate(parameters);
            ScenarioContext.Current.ChargeAmount(chargeAmount);
        }

        [When("I leave at (.*) AM$")]
        public void WhenILeaveAt(string time)
        {
            var leaveTime = time.ToLocalDateTime().PlusDays(1);
            var parameters = new NightlyChargeParameters(
                ScenarioContext.Current.ArrivalTime(),
                ScenarioContext.Current.Bedtime(),
                leaveTime,
                ScenarioContext.Current.HourlyRate(),
                ScenarioContext.Current.HourlyRateBetweenBedtimeAndMidnight(),
                ScenarioContext.Current.HourlyRateAfterMidnight());
            
            var calculator = new NightlyChargeCalculator();
            var chargeAmount = calculator.Calculate(parameters);
            ScenarioContext.Current.ChargeAmount(chargeAmount);
        }

        [Then("I should charge \\$(\\d*)$")]
        public void ThenIShouldBePaid(long chargeAmount)
        {
            var actual = ScenarioContext.Current.ChargeAmount();
            Assert.Equal(chargeAmount, actual);
        }
    }
}