using Xunit;

namespace BabySitter.Core.Test
{
    public class StringExtensionsTests
    {
        [Fact]
        public void ShouldConvertPmToMilitaryTime()
        {
            var time = "5:00 PM".ToLocalDateTime();
            Assert.Equal(17, time.Hour);
        }
        
        [Fact]
        public void ShouldConvertMidnightToMilitaryTime()
        {
            var time = "12:00 AM".ToLocalDateTime();
            Assert.Equal(0, time.Hour);
        }
    }
}