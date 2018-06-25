using System.Threading.Tasks;
using BabySitter.Core.Models;
using BabySitter.Web.Test.General;
using Xunit;

namespace BabySitter.Web.Test
{
    [Collection(ServerFixtureCollection.Name)]
    public class GetBabySittersTests
    {
        private readonly ServerFixture _fixture;

        public GetBabySittersTests(ServerFixture fixture)
        {
            _fixture = fixture;
            _fixture.ClearDatabase();
        }

        [Fact]
        public async Task ShouldGetAllBabySitters()
        {
            _fixture.Add(ModelFactory.CreateBabySitter());
            _fixture.Add(ModelFactory.CreateBabySitter());
            _fixture.Add(ModelFactory.CreateBabySitter());
            
            using (var client = _fixture.CreateClient())
            {
                var babySitters = await client.GetJsonAsync<SitterModel[]>("babysitters");
                Assert.Equal(3, babySitters.Length);
            }
        }
        
        [Fact]
        public async Task ShouldPopulateBabySitterItems()
        {
            var babySitter = ModelFactory.CreateBabySitter();
            _fixture.Add(babySitter);

            using (var client = _fixture.CreateClient())
            {
                var babySitters = await client.GetJsonAsync<SitterModel[]>("babysitters");
                var actual = babySitters[0];
                Assert.Equal(babySitter.FirstName, actual.FirstName);
                Assert.Equal(babySitter.LastName, actual.LastName);
                Assert.Equal(babySitter.Id, actual.Id);
            }
        }
    }
}