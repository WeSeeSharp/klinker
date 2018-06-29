using System.Threading.Tasks;
using BabySitter.Web.Test.General;
using Xunit;

namespace BabySitter.Web.Test.BabySitters
{
    [Collection(ServerFixtureCollection.Name)]
    public class UpdateBabySitterTests
    {
        private readonly ServerFixture _fixture;

        public UpdateBabySitterTests(ServerFixture fixture)
        {
            _fixture = fixture;
            _fixture.ClearDatabase();
        }
        
        [Fact]
        public async Task ShouldUpdateBabySitterRates()
        {
            var sitter = await _fixture.AddBabySitter("515", "Jack");
            await _fixture.UpdateBabySitter(sitter.Id, "Humble", "Bob", 50, 20, 90);
            var updatedModel = await _fixture.GetBabySitter(sitter.Id);
            
            Assert.Equal("Humble", updatedModel.FirstName);
            Assert.Equal("Bob", updatedModel.LastName);
            Assert.Equal(50, updatedModel.HourlyRate);
            Assert.Equal(90, updatedModel.HourlyRateAfterMidnight);
            Assert.Equal(20, updatedModel.HourlyRateBetweenBedtimeAndMidnight);
        }
    }
}