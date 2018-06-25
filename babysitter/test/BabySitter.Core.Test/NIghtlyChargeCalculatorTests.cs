using System;
using NodaTime;
using Xunit;

namespace BabySitter.Core.Test
{
    public class NIghtlyChargeCalculatorTests
    {
        [Fact]
        public void ShouldThrowInvalidOperationWhenArrivalIsBefore1700Hours()
        {
            var parameters = new NightlyChargeParameters(
                new LocalTime(16, 59),
                new LocalTime(),
                new LocalTime(),
                12);
            var calculator = new NightlyChargeCalculator();
            Assert.Throws<InvalidOperationException>(() => calculator.Calculate(parameters));
        }
        
        [Fact]
        public void ShouldCalculateChargeForThreeHoursAtNormalRate()
        {
            var parameters = new NightlyChargeParameters(
                new LocalTime(17, 0),
                new LocalTime(23, 0),
                new LocalTime(20, 0),
                12);
            
            var calculator = new NightlyChargeCalculator();
            var chargeAmount = calculator.Calculate(parameters);
            Assert.Equal(36, chargeAmount);
        }
    }
}