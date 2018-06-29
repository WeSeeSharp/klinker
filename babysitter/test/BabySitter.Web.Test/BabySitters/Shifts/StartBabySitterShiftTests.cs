using System.Threading.Tasks;
using BabySitter.Web.Test.General;
using NodaTime;
using Xunit;

namespace BabySitter.Web.Test.BabySitters.Shifts
{
    [Collection(ServerFixtureCollection.Name)]
    public class StartBabySitterShiftTests
    {
        private readonly ServerFixture _fixture;

        public StartBabySitterShiftTests(ServerFixture fixture)
        {
            _fixture = fixture;
            _fixture.ClearDatabase();
        }
        
        [Fact]
        public async Task ShouldCreateShiftForSitter()
        {
            var startTime = new LocalDateTime(2018, 12, 8, 17, 0);
            var bedTime = new LocalDateTime(2018, 12, 7, 21, 0);
            
            var sitter = await _fixture.AddBabySitter("John", "Doe");
            var shift = await _fixture.StartShift(sitter.Id, startTime, bedTime);
            
            Assert.NotEqual(0, shift.Id);
            Assert.Equal(startTime, shift.StartTime);
            Assert.Equal(bedTime, shift.Bedtime);
            Assert.Equal(12, shift.HourlyRate);
            Assert.Equal(8, shift.HourlyRateBetweenBedtimeAndMidnight);
            Assert.Equal(16, shift.HourlyRateAfterMidnight);
        }
    }
}