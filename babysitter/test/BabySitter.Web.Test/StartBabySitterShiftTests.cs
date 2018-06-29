using System;
using System.Threading.Tasks;
using BabySitter.Core.Entities;
using BabySitter.Core.Models;
using BabySitter.Web.Test.General;
using Microsoft.Win32.SafeHandles;
using NodaTime;
using Xunit;

namespace BabySitter.Web.Test
{
    [Collection(ServerFixtureCollection.Name)]
    public class BabySitterShiftsTests
    {
        private readonly ServerFixture _fixture;

        public BabySitterShiftsTests(ServerFixture fixture)
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