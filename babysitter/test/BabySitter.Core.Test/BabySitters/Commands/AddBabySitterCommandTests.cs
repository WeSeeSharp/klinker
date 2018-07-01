using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Commands;
using BabySitter.Core.BabySitters.Entities;
using BabySitter.Core.BabySitters.Validation;
using BabySitter.Core.General;
using BabySitter.Core.Test.Utilties;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using ValidationException = BabySitter.Core.General.Validation.ValidationException;

namespace BabySitter.Core.Test.BabySitters.Commands
{
    public class AddBabySitterCommandTests
    {
        private readonly DatabaseContext _context;
        private readonly AddBabySitterCommand _command;

        public AddBabySitterCommandTests()
        {
            var provider = ServiceProviderFactory.Create();
            _context = provider.GetService<DatabaseContext>();
            _command = new AddBabySitterCommand(_context, new SitterValidator());
        }
        
        [Fact]
        public async Task ShouldAddBabySitterWithDefaultRates()
        {
            var args = new AddBabySitterArgs("Jack", "Billy");
            var model = await _command.Execute(args);
            
            var sitter = _context.Find<Sitter>(model.Id);
            Assert.Equal("Jack", sitter.FirstName);
            Assert.Equal("Billy", sitter.LastName);
            Assert.Equal(12, sitter.HourlyRates.Standard);
            Assert.Equal(8, sitter.HourlyRates.BetweenBedtimeAndMidnight);
            Assert.Equal(16, sitter.HourlyRates.AfterMidnight);
        }
        
        [Fact]
        public async Task ShouldADdBabySitterWithSpecifiedRates()
        {
            var args = new AddBabySitterArgs("one", "two", 32, 20, 89);
            var model = await _command.Execute(args);

            var sitter = _context.Find<Sitter>(model.Id);
            Assert.Equal("one", sitter.FirstName);
            Assert.Equal("two", sitter.LastName);
            Assert.Equal(32, sitter.HourlyRates.Standard);
            Assert.Equal(20, sitter.HourlyRates.BetweenBedtimeAndMidnight);
            Assert.Equal(89, sitter.HourlyRates.AfterMidnight);
        }
        
        [Fact]
        public async Task ShouldThrowValidationException()
        {
            var args = new AddBabySitterArgs(null, "bob");

            await Assert.ThrowsAsync<ValidationException>(() => _command.Execute(args));
        }
    }
}