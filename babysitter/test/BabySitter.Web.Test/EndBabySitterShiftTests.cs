using System.Threading.Tasks;
using BabySitter.Core.Models;
using BabySitter.Web.Test.General;
using NodaTime;
using Xunit;

namespace BabySitter.Web.Test
{
    [Collection(ServerFixtureCollection.Name)]
    public class EndBabySitterShiftTests
    {
        private readonly ServerFixture _fixture;

        public EndBabySitterShiftTests(ServerFixture fixture)
        {
            _fixture = fixture;
        }
        
        [Fact]
        public async Task ShouldUpdateSitterShiftWithEndDate()
        {
            var sitter = new {FirstName = "Bob", LastName = "Jack"};
            var shift = new
            {
                StartTime = new LocalDateTime(2018, 4, 12, 17, 0), 
                Bedtime = new LocalDateTime(2018, 4, 12, 21, 0)
            };
            using (var client = _fixture.CreateClient())
            {
                var sitterResponse = await client.PostJsonAsync("babysitters", sitter);
                var sitterId = (await client.GetJsonAsync<SitterModel>(sitterResponse.Headers.Location)).Id;

                var startResponse = await client.PostJsonAsync($"babysitters/{sitterId}/startshift", shift);
                var shiftId = (await client.GetJsonAsync<ShiftModel>(startResponse.Headers.Location)).Id;

                var endTime = new LocalDateTime(2018, 4, 12, 22, 0);
                await client.PutJsonAsync($"babysitters/{sitterId}/shifts/{shiftId}/endShift", new { EndTime = endTime });
                var updatedShift = await client.GetJsonAsync<ShiftModel>(startResponse.Headers.Location);
                Assert.Equal(endTime, updatedShift.EndTime);
            }
        }
    }
}