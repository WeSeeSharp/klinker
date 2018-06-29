using System.Threading.Tasks;
using BabySitter.Web.Test.General;
using Xunit;

namespace BabySitter.Web.Test.BabySitters
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
            await _fixture.AddBabySitter("one", "two");
            await _fixture.AddBabySitter("three", "four");
            await _fixture.AddBabySitter("Jack", "Jill");

            var babySitters = await _fixture.GetBabySitters();
            Assert.Equal(3, babySitters.Length);
        }
        
        [Fact]
        public async Task ShouldPopulateBabySitterItems()
        {
            var newSitter = await _fixture.AddBabySitter("hello", "bob");

            var actual = (await _fixture.GetBabySitters())[0];
            Assert.Equal("hello", actual.FirstName);
            Assert.Equal("bob", actual.LastName);
            Assert.Equal(newSitter.Id, actual.Id);
        }
    }
}