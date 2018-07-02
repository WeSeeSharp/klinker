using System.Linq;
using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Entities;
using BabySitter.Core.BabySitters.Shifts.Commands;
using BabySitter.Core.BabySitters.Shifts.Validation;
using BabySitter.Core.General;
using BabySitter.Core.General.Validation;
using BabySitter.Core.Test.Utilties;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BabySitter.Core.Test.BabySitters.Shifts.Commands
{
    public class StartShiftCommandTests
    {
        private readonly DatabaseContext _context;
        private readonly StartShiftCommand _command;

        public StartShiftCommandTests()
        {
            var provider = ServiceProviderFactory.Create();
            _context = provider.GetService<DatabaseContext>();

            _command = new StartShiftCommand(_context, new ShiftValidator());
        }
        
        [Fact]
        public async Task ShouldCreateShiftWithStartTime()
        {
            var sitter = _context.Add(ModelFactory.CreateSitter()).Entity;
            _context.SaveChanges();

            var startTime = "5:00 PM".ToLocalDateTime();
            var bedTime = "7:00 PM".ToLocalDateTime();
            var args = new StartShiftArgs(sitter.Id, startTime, bedTime);
            await _command.Execute(args);

            var shift = _context.Shifts.First();
            Assert.Equal(startTime, shift.StartTime);
            Assert.Equal(bedTime, shift.Bedtime);
            Assert.Equal(sitter.HourlyRates, shift.HourlyRates);
        }
        
        [Fact]
        public async Task ShouldThrowEntityNotFoundException()
        {
            var args = new StartShiftArgs(int.MaxValue, "5:00 PM".ToLocalDateTime(), "11:00 PM".ToLocalDateTime());
            await Assert.ThrowsAsync<EntityNotFoundException<Sitter>>(() => _command.Execute(args));
        }
        
        [Fact]
        public async Task ShouldThrowValidationException()
        {
            var sitter = _context.Add(ModelFactory.CreateSitter()).Entity;
            _context.SaveChanges();

            var startTime = "5:00 PM".ToLocalDateTime();
            var bedTime = "8:00 PM".ToLocalDateTime();
            var args = new StartShiftArgs(sitter.Id, startTime, bedTime);
            await _command.Execute(args);
            await Assert.ThrowsAsync<ValidationException>(() => _command.Execute(args));
        }
    }
}