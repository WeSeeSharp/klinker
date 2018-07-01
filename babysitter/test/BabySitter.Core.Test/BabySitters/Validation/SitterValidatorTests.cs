using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Validation;
using BabySitter.Core.Test.Utilties;
using Xunit;

namespace BabySitter.Core.Test.BabySitters.Validation
{
    public class SitterValidatorTests
    {
        private readonly SitterValidator _validator;

        public SitterValidatorTests()
        {
            _validator = new SitterValidator();
        }
        
        [Fact]
        public async Task ShouldBeInvalidWhenNullFirstName()
        {
            var sitter = ModelFactory.CreateSitter();
            sitter.FirstName = null;

            var result = await _validator.Validate(sitter);
            Assert.False(result.IsValid);
        }
        
        [Fact]
        public async Task ShouldBeInvalidWhenEmptyFirstName()
        {
            var sitter = ModelFactory.CreateSitter();
            sitter.FirstName = string.Empty;

            var result = await _validator.Validate(sitter);
            Assert.False(result.IsValid);
        }
        
        [Fact]
        public async Task ShouldBeInvalidWhenLastNameIsNull()
        {
            var sitter = ModelFactory.CreateSitter();
            sitter.LastName = null;

            var result = await _validator.Validate(sitter);
            Assert.False(result.IsValid);
        }
        
        [Fact]
        public async Task ShouldBeInvalidWhenLastNameIsEmpty()
        {
            var sitter = ModelFactory.CreateSitter();
            sitter.LastName = string.Empty;

            var result = await _validator.Validate(sitter);
            Assert.False(result.IsValid);
        }
        
        [Fact]
        public async Task ShouldBeInvalidWhenHourlyRatesIsNull()
        {
            var sitter = ModelFactory.CreateSitter();
            sitter.HourlyRates = null;

            var result = await _validator.Validate(sitter);
            Assert.False(result.IsValid);
        }
        
        [Fact]
        public async Task ShouldBeValid()
        {
            var sitter = ModelFactory.CreateSitter();

            var result = await _validator.Validate(sitter);
            Assert.True(result.IsValid);
        }
    }
}