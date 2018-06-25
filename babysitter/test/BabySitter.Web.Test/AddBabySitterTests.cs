using System.Threading.Tasks;
using BabySitter.Core.Models;
using BabySitter.Web.Test.General;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Xunit;

namespace BabySitter.Web.Test
{
    [Collection(ServerFixtureCollection.Name)]
    public class AddBabySitterTests
    {
        private readonly ServerFixture _fixture;

        public AddBabySitterTests(ServerFixture fixture)
        {
            _fixture = fixture;
            _fixture.ClearDatabase();
        }
        
        [Fact]
        public async Task ShouldAddBabySitterWithStandardRates()
        {
            var newBabySitter = new
            {
                FirstName = "Jack",
                LastName = "Jill"
            };

            using (var client = _fixture.CreateClient())
            {
                var response = await client.PostJsonAsync("babysitters", newBabySitter);
                var babySitter = await client.GetJsonAsync<SitterModel>(response.Headers.Location);
                Assert.Equal("Jack", babySitter.FirstName);
                Assert.Equal("Jill", babySitter.LastName);
                Assert.Equal(12, babySitter.HourlyRate);
                Assert.Equal(8, babySitter.HourlyRateBetweenBedtimeAndMidnight);
                Assert.Equal(16, babySitter.HourlyRateAfterMidnight);
            }
        }
        
        [Fact]
        public async Task ShouldAddBabySitterWithCustomRates()
        {
            var newBabySitter = new
            {
                FirstName = "Will",
                LastName = "Bogus",
                HourlyRate = 15,
                HourlyRateAfterMidnight = 20,
                HourlyRateBetweenBedtimeAndMidnight = 12
            };

            using (var client = _fixture.CreateClient())
            {
                var response = await client.PostJsonAsync("babysitters", newBabySitter);
                var babySitter = await client.GetJsonAsync<SitterModel>(response.Headers.Location);
                Assert.Equal("Will", babySitter.FirstName);
                Assert.Equal("Bogus", babySitter.LastName);
                Assert.Equal(15, babySitter.HourlyRate);
                Assert.Equal(12, babySitter.HourlyRateBetweenBedtimeAndMidnight);
                Assert.Equal(20, babySitter.HourlyRateAfterMidnight);
            }
        }
    }
}