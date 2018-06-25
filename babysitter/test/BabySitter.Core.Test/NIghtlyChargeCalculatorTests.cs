using System;
using System.Net.Http.Headers;
using NodaTime;
using Xunit;

namespace BabySitter.Core.Test
{
    public class NIghtlyChargeCalculatorTests
    {
        [Fact]
        public void ShouldCalculateChargeForThreeHoursAtNormalRate()
        {
            var parameters = new NightlyChargeParameters(
                new LocalDateTime(1, 1, 1, 17, 0),
                new LocalDateTime(1, 1, 1, 23, 0),
                new LocalDateTime(1, 1, 1, 20, 0));

            var calculator = new NightlyChargeCalculator();
            var chargeAmount = calculator.Calculate(parameters);
            Assert.Equal(36, chargeAmount);
        }

        [Fact]
        public void ShouldThrowInvalidOperationWhenArrivalIsBefore1700Hours()
        {
            var parameters = new NightlyChargeParameters(
                new LocalDateTime(1, 1, 1, 16, 59),
                new LocalDateTime(1, 1, 1, 0, 0),
                new LocalDateTime(1, 1, 1, 0, 0));
            var calculator = new NightlyChargeCalculator();
            Assert.Throws<InvalidOperationException>(() => calculator.Calculate(parameters));
        }

        [Fact]
        public void ShouldThrowInvalidOperationWhenLeavetimeIsAfter400Hours()
        {
            var parameters = new NightlyChargeParameters(
                new LocalDateTime(1, 1, 1, 17, 0, 0),
                new LocalDateTime(1, 1, 1, 9, 0, 0),
                new LocalDateTime(1, 1, 2, 4, 1, 0));
            
            var calculator = new NightlyChargeCalculator();
            Assert.Throws<InvalidOperationException>(() => calculator.Calculate(parameters));
        }

        [Fact]
        public void ShouldCalculateChargeForTimeBetweenBedtimeAndMidnight()
        {
            var parameters = new NightlyChargeParameters(
                new LocalDateTime(1, 1, 1, 21, 0),
                new LocalDateTime(1, 1, 1, 21, 0),
                new LocalDateTime(1, 1, 2, 0, 0));
            
            var calculator = new NightlyChargeCalculator();
            var chargeAmount = calculator.Calculate(parameters);
            Assert.Equal(24, chargeAmount);
        }
        
        [Fact]
        public void ShouldCalculateChargeForTimeAfterMidnight()
        {
            var parameters = new NightlyChargeParameters(
                new LocalDateTime(1, 1, 1, 21, 0),
                new LocalDateTime(1, 1, 1, 21, 0),
                new LocalDateTime(1, 1, 2, 4, 0));
            
            var calculator = new NightlyChargeCalculator();
            var chargeAmount = calculator.Calculate(parameters);
            Assert.Equal(88, chargeAmount);
        }
    }
}