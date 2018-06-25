using System;
using BabySitter.Specs.Support.Steps;

namespace BabySitter.Specs.Steps
{
    public class BabySitterFeatureSteps
    {
        [Given("I arrive at (.*)")]
        public void GivenIArriveAt(string time)
        {
            
        }

        [Given("I charge \\$(\\d*) per hour")]
        public void GivenICharge(string hourlyRate)
        {
            
        }

        [Given("bedtime is (.*)")]
        public void GivenBedtimeIs(string bedtime)
        {
            
        }

        [When("I leave at bedtime")]
        public void WhenILeaveAtBedtime()
        {
            
        }

        [Then("I should be paid \\$(\\d*)")]
        public void ThenIShouldBePaid(int payment)
        {
            
        }
    }
}