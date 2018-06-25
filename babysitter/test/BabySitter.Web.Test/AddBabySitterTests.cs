using System.Threading.Tasks;
using BabySitter.Core.Models;
using BabySitter.Web.Test.General;
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
        public async Task ShouldAddBabySitter()
        {
            var newBabySitter = new
            {
                FirstName = "Jack",
                LastName = "Jill",
            };

            using (var client = _fixture.CreateClient())
            {
                var response = await client.PostJsonAsync("babysitters", newBabySitter);
                var babySitter = await client.GetJsonAsync<BabySitterModel>(response.Headers.Location);
                Assert.Equal("Jack", babySitter.FirstName);
                Assert.Equal("Jill", babySitter.LastName);
            }
        }
    }
}