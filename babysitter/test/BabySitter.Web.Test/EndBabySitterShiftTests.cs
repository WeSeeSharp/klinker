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
            var sitter = await _fixture.AddBabySitter("Bob", "Jack");
            var shift = await _fixture.StartShift(
                sitter.Id, 
                new LocalDateTime(2018, 4, 12, 17, 0),
                new LocalDateTime(2018, 4, 12, 21, 0));

            var endTime = new LocalDateTime(2018, 4, 12, 22, 0);
            await _fixture.EndShift(sitter.Id, shift.Id, endTime);
            var updatedShift = await _fixture.GetBabySitterShift(sitter.Id, shift.Id);
            Assert.Equal(endTime, updatedShift.EndTime);
        }
    }
}