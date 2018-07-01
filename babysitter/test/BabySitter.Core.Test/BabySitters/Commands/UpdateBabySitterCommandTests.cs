using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Commands;
using BabySitter.Core.BabySitters.Entities;
using BabySitter.Core.BabySitters.Validation;
using BabySitter.Core.General;
using BabySitter.Core.General.Validation;
using BabySitter.Core.Test.Utilties;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BabySitter.Core.Test.BabySitters.Commands
{
    public class UpdateBabySitterCommandTests
    {
        private readonly DatabaseContext _context;
        private readonly UpdateBabySitterCommand _command;

        public UpdateBabySitterCommandTests()
        {
            var provider = ServiceProviderFactory.Create();
            _context = provider.GetService<DatabaseContext>();
            _command = new UpdateBabySitterCommand(_context, new SitterValidator());
        }
        
        [Fact]
        public async Task ShouldUpdateSitter()
        {
            var sitter = _context.Add(ModelFactory.CreateSitter()).Entity;
            _context.SaveChanges();

            var args = new UpdateBabySitterArgs(
                sitter.Id,
                "Bob",
                "John",
                45,
                12,
                100);

            await _command.Execute(args);
            Assert.Equal("Bob", sitter.FirstName);
            Assert.Equal("John", sitter.LastName);
            Assert.Equal(45, sitter.HourlyRates.Standard);
            Assert.Equal(12, sitter.HourlyRates.BetweenBedtimeAndMidnight);
            Assert.Equal(100, sitter.HourlyRates.AfterMidnight);
        }
        
        [Fact]
        public async Task ShouldThrowEntityNotFoundException()
        {
            var args = new UpdateBabySitterArgs(int.MaxValue, "12", "3", 1, 1, 1);
            await Assert.ThrowsAsync<EntityNotFoundException<Sitter>>(() => _command.Execute(args));
        }
        
        [Fact]
        public async Task ShouldThrowValidationException()
        {
            var sitter = _context.Add(ModelFactory.CreateSitter()).Entity;
            _context.SaveChanges();

            var args = new UpdateBabySitterArgs(sitter.Id, null, null, 3, 2, 1);
            await Assert.ThrowsAsync<ValidationException>(() => _command.Execute(args));
        }
    }
}