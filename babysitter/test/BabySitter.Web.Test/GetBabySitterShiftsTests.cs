using System.Threading.Tasks;
using BabySitter.Web.Test.General;
using NodaTime;
using Xunit;

namespace BabySitter.Web.Test
{
    [Collection(ServerFixtureCollection.Name)]
    public class GetBabySitterShiftsTests
    {
        private readonly ServerFixture _fixture;

        public GetBabySitterShiftsTests(ServerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ShouldReturnAllShiftsForBabySitter()
        {
            var sitter = await _fixture.AddBabySitter("one", "two");
            await _fixture.StartShift(sitter.Id, new LocalDateTime(2018, 6, 3, 17, 0), new LocalDateTime(2018, 5, 3, 20, 0));
            await _fixture.StartShift(sitter.Id, new LocalDateTime(2018, 6, 4, 17, 0), new LocalDateTime(2018, 5, 4, 20, 0));
            await _fixture.StartShift(sitter.Id, new LocalDateTime(2018, 6, 5, 17, 0), new LocalDateTime(2018, 5, 5, 20, 0));
            
            var shifts = await _fixture.GetBabySitterShifts(sitter.Id);
            Assert.Equal(3, shifts.Length);
        }
    }
}