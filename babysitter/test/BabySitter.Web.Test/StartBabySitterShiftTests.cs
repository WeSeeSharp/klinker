using System;
using System.Threading.Tasks;
using BabySitter.Core.Entities;
using BabySitter.Core.Models;
using BabySitter.Web.Test.General;
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
        }
        
        [Fact]
        public async Task ShouldCreateShiftForSitter()
        {
            var sitter = new {FirstName = "John", LastName = "Doe"};
            using (var client = _fixture.CreateClient())
            {
                var createSitterResponse = await client.PostJsonAsync("babysitters", sitter);
                var sitterId = (await createSitterResponse.ReadAsJsonAsync<SitterModel>()).Id;


                var startTime = new LocalDateTime(2018, 12, 8, 17, 0);
                var bedTime = new LocalDateTime(2018, 12, 7, 21, 0);
                var startShiftResponse = await client.PostJsonAsync($"babysitters/{sitterId}/startShift", new { StartTime = startTime, Bedtime = bedTime});
                var shift = await client.GetJsonAsync<ShiftModel>(startShiftResponse.Headers.Location);

                Assert.NotEqual(0, shift.Id);
                Assert.Equal(startTime, shift.StartTime);
                Assert.Equal(bedTime, shift.Bedtime);
                Assert.Equal(12, shift.HourlyRate);
                Assert.Equal(8, shift.HourlyRateBetweenBedtimeAndMidnight);
                Assert.Equal(16, shift.HourlyRateAfterMidnight);
            }
        }
    }
}