using System.Threading.Tasks;
using BabySitter.Core.Models;
using BabySitter.Web.Test.General;
using Xunit;

namespace BabySitter.Web.Test
{
    [Collection(ServerFixtureCollection.Name)]
    public class UpdateBabySitterTests
    {
        private readonly ServerFixture _fixture;

        public UpdateBabySitterTests(ServerFixture fixture)
        {
            _fixture = fixture;
        }
        
        [Fact]
        public async Task ShouldUpdateBabySitterRates()
        {
            var sitter = _fixture.Add(ModelFactory.CreateBabySitter());
            using (var client = _fixture.CreateClient())
            {
                var model = await client.GetJsonAsync<SitterModel>($"babysitters/{sitter.Id}");
                model.FirstName = "515";
                model.LastName = "Jack";
                model.HourlyRate = 50;
                model.HourlyRateAfterMidnight = 90;
                model.HourlyRateBetweenBedtimeAndMidnight = 20;
                await client.PutJsonAsync($"babysitters/{sitter.Id}", model);

                var updatedModel = await client.GetJsonAsync<SitterModel>($"babysitters/{sitter.Id}");
                Assert.Equal("515", updatedModel.FirstName);
                Assert.Equal("Jack", updatedModel.LastName);
                Assert.Equal(50, updatedModel.HourlyRate);
                Assert.Equal(90, updatedModel.HourlyRateAfterMidnight);
                Assert.Equal(20, updatedModel.HourlyRateBetweenBedtimeAndMidnight);
            }
        }
    }
}