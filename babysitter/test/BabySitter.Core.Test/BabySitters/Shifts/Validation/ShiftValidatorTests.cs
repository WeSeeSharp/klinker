using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Shifts.Validation;
using BabySitter.Core.Test.Utilties;
using NodaTime;
using Xunit;

namespace BabySitter.Core.Test.BabySitters.Shifts.Validation
{
    public class ShiftValidatorTests
    {
        private readonly ShiftValidator _validator;

        public ShiftValidatorTests()
        {
            _validator = new ShiftValidator();
        }
        
        [Fact]
        public async Task ShouldBeInvalidWhenEndTimeIsBeforeStartTime()
        {
            var shift = ModelFactory.CreateShift(
                startTime: new LocalDateTime(2018, 7, 1, 17, 00),
                endtime: new LocalDateTime(2018, 7, 1, 16, 0));

            var result = await _validator.Validate(shift);
            Assert.True(result.Invalid);
        }
        
        [Fact]
        public async Task ShouldBeValidWhenEndtimeIsAfterStartTime()
        {
            var shift = ModelFactory.CreateShift(
                startTime: new LocalDateTime(2018, 7, 1, 17, 00),
                endtime: new LocalDateTime(2018, 7, 1, 18, 0));

            var result = await _validator.Validate(shift);
            Assert.False(result.Invalid);
        }
        
        [Fact]
        public async Task ShouldBeValidWhenEndTimeIsNull()
        {
            var shift = ModelFactory.CreateShift(
                startTime: new LocalDateTime(2018, 7, 1, 17, 00));
            shift.EndTime = null;
                
            var result = await _validator.Validate(shift);
            Assert.False(result.Invalid);
        }
        
        [Fact]
        public async Task ShouldBeInvalidWhenStartTimeIsBefore5Pm()
        {
            var shift = ModelFactory.CreateShift(
                startTime: new LocalDateTime(2018, 7, 1, 16, 0));

            var result = await _validator.Validate(shift);
            Assert.True(result.Invalid);
        }
        
        [Fact]
        public async Task ShouldBeInvalidWhenHourlyRatesIsNull()
        {
            var shift = ModelFactory.CreateShift();
            shift.HourlyRates = null;

            var result = await _validator.Validate(shift);
            Assert.True(result.Invalid);
        }
        
        [Fact]
        public async Task ShouldBeInvalidWhenEndTimeIsAfter4Am()
        {
            var shift = ModelFactory.CreateShift(
                startTime: new LocalDateTime(2018, 7, 1, 17, 0),
                endtime: new LocalDateTime(2018, 7, 2, 5, 0));

            var result = await _validator.Validate(shift);
            Assert.True(result.Invalid);
        }
        
        [Fact]
        public async Task ShouldOnlyAllowOneActiveShiftForSitter()
        {
            var sitter = ModelFactory.CreateSitter();
            var firstShift = ModelFactory.CreateShift();
            firstShift.EndTime = null;
            sitter.Shifts.Add(firstShift);
            
            var secondShift = ModelFactory.CreateShift(sitter);
            secondShift.EndTime = null;

            var result = await _validator.Validate(secondShift);
            Assert.True(result.Invalid);
        }
    }
}