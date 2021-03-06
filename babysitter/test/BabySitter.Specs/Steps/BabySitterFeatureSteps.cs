﻿using BabySitter.Core;
using BabySitter.Core.BabySitters;
using BabySitter.Core.BabySitters.Shifts.Services;
using NodaTime;
using Xunit;
using Xunit.Gherkin.Scenarios;
using Xunit.Gherkin.Steps;

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
            var parameters = CreateParameters(ScenarioContext.Current.Bedtime());

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
            var parameters = CreateParameters(midnight.AtMidnight());

            var calculator = new NightlyChargeCalculator();
            var chargeAmount = calculator.Calculate(parameters);
            ScenarioContext.Current.ChargeAmount(chargeAmount);
        }

        [When("I leave at (.*) (AM|PM)$")]
        public void WhenILeaveAt(string time, string amOrPm)
        {
            var leaveTime = $"{time} {amOrPm}".ToLocalDateTime();
            leaveTime = amOrPm == "AM" ? leaveTime.PlusDays(1) : leaveTime;

            var parameters = CreateParameters(leaveTime);

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

        private static NightlyChargeArgs CreateParameters(LocalDateTime leaveTime)
        {
            return new NightlyChargeArgs(
                ScenarioContext.Current.ArrivalTime(),
                ScenarioContext.Current.Bedtime(),
                leaveTime,
                ScenarioContext.Current.HourlyRate(),
                ScenarioContext.Current.HourlyRateBetweenBedtimeAndMidnight(),
                ScenarioContext.Current.HourlyRateAfterMidnight());
        }
    }
}