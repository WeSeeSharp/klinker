using System.Threading.Tasks;
using BabySitter.Web.Test.General;
using Xunit;

namespace BabySitter.Web.Test.BabySitters
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
            var babySitter = await _fixture.AddBabySitter("Jack", "Jill");
            Assert.Equal("Jack", babySitter.FirstName);
            Assert.Equal("Jill", babySitter.LastName);
            Assert.Equal(12, babySitter.HourlyRate);
            Assert.Equal(8, babySitter.HourlyRateBetweenBedtimeAndMidnight);
            Assert.Equal(16, babySitter.HourlyRateAfterMidnight);
        }
        
        [Fact]
        public async Task ShouldAddBabySitterWithCustomRates()
        {
            var babySitter = await _fixture.AddBabySitter("Will", "Bogus", 15, 12, 20);
            Assert.Equal("Will", babySitter.FirstName);
            Assert.Equal("Bogus", babySitter.LastName);
            Assert.Equal(15, babySitter.HourlyRate);
            Assert.Equal(12, babySitter.HourlyRateBetweenBedtimeAndMidnight);
            Assert.Equal(20, babySitter.HourlyRateAfterMidnight);
        }
    }
}