using System.Net;
using System.Threading.Tasks;
using BabySitter.Web.Test.General;
using Xunit;

namespace BabySitter.Web.Test.BabySitters
{
    [Collection(ServerFixtureCollection.Name)]
    public class BabySittersControllerTests
    {
        private readonly ServerFixture _fixture;

        public BabySittersControllerTests(ServerFixture fixture)
        {
            _fixture = fixture;
        }
        
        [Fact]
        public async Task ShouldReturn404IfSitterIsNotFound()
        {
            using (var client = _fixture.CreateClient())
            {
                var response = await client.GetAsync("babysitters/45");
                Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            }
        }
        
        [Fact]
        public async Task ShouldReturn400IfSitterCreatedWithoutNames()
        {
            using (var client = _fixture.CreateClient())
            {
                var response = await client.PostJsonAsync<object>("babysitters", new { FirstName = "Bob" });
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }
    }
}