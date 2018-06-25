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
    }
}