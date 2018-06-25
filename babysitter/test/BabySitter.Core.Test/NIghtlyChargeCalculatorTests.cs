using System;
using NodaTime;
using Xunit;

namespace BabySitter.Core.Test
{
    public class NIghtlyChargeCalculatorTests
    {
        public NIghtlyChargeCalculatorTests()
        {
            _calculator = new NightlyChargeCalculator();
        }

        private readonly NightlyChargeCalculator _calculator;

        [Fact]
        public void ShouldCalculateChargeForFullHourOfArrival()
        {
            var parameters = new NightlyChargeParameters(
                new LocalDateTime(1, 1, 1, 17, 45),
                new LocalDateTime(1, 1, 1, 21, 0),
                new LocalDateTime(1, 1, 1, 19, 45));

            var chargeAmount = _calculator.Calculate(parameters);
            Assert.Equal(36, chargeAmount);
        }

        [Fact]
        public void ShouldCalculateChargeForFullHourOfBedtime()
        {
            var parameters = new NightlyChargeParameters(
                new LocalDateTime(1, 1, 1, 17, 45),
                new LocalDateTime(1, 1, 1, 21, 30),
                new LocalDateTime(1, 1, 1, 22, 45));

            var chargeAmount = _calculator.Calculate(parameters);
            Assert.Equal(68, chargeAmount);
        }

        [Fact]
        public void ShouldCalculateChargeForFullHoursNoPartialHours()
        {
            var parameters = new NightlyChargeParameters(
                new LocalDateTime(1, 1, 1, 17, 0),
                new LocalDateTime(1, 1, 1, 21, 0),
                new LocalDateTime(1, 1, 1, 19, 45));

            var chargeAmount = _calculator.Calculate(parameters);
            Assert.Equal(36, chargeAmount);
        }

        [Fact]
        public void ShouldCalculateChargeForThreeHoursAtNormalRate()
        {
            var parameters = new NightlyChargeParameters(
                new LocalDateTime(1, 1, 1, 17, 0),
                new LocalDateTime(1, 1, 1, 23, 0),
                new LocalDateTime(1, 1, 1, 20, 0));

            var chargeAmount = _calculator.Calculate(parameters);
            Assert.Equal(36, chargeAmount);
        }

        [Fact]
        public void ShouldCalculateChargeForTimeAfterMidnight()
        {
            var parameters = new NightlyChargeParameters(
                new LocalDateTime(1, 1, 1, 21, 0),
                new LocalDateTime(1, 1, 1, 21, 0),
                new LocalDateTime(1, 1, 2, 4, 0));

            var chargeAmount = _calculator.Calculate(parameters);
            Assert.Equal(88, chargeAmount);
        }

        [Fact]
        public void ShouldCalculateChargeForTimeBetweenBedtimeAndMidnight()
        {
            var parameters = new NightlyChargeParameters(
                new LocalDateTime(1, 1, 1, 21, 0),
                new LocalDateTime(1, 1, 1, 21, 0),
                new LocalDateTime(1, 1, 2, 0, 0));

            var chargeAmount = _calculator.Calculate(parameters);
            Assert.Equal(24, chargeAmount);
        }

        [Fact]
        public void ShouldThrowInvalidOperationWhenArrivalIsBefore1700Hours()
        {
            var parameters = new NightlyChargeParameters(
                new LocalDateTime(1, 1, 1, 16, 59),
                new LocalDateTime(1, 1, 1, 0, 0),
                new LocalDateTime(1, 1, 1, 0, 0));

            Assert.Throws<InvalidOperationException>(() => _calculator.Calculate(parameters));
        }

        [Fact]
        public void ShouldThrowInvalidOperationWhenLeavetimeIsAfter400Hours()
        {
            var parameters = new NightlyChargeParameters(
                new LocalDateTime(1, 1, 1, 17, 0, 0),
                new LocalDateTime(1, 1, 1, 9, 0, 0),
                new LocalDateTime(1, 1, 2, 4, 1, 0));

            Assert.Throws<InvalidOperationException>(() => _calculator.Calculate(parameters));
        }
    }
}