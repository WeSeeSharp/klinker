using System;
using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Entities;
using BabySitter.Core.BabySitters.Shifts.Commands;
using BabySitter.Core.BabySitters.Shifts.Entities;
using BabySitter.Core.BabySitters.Shifts.Validation;
using BabySitter.Core.General;
using BabySitter.Core.General.Validation;
using BabySitter.Core.Test.Utilties;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;
using Xunit;

namespace BabySitter.Core.Test.BabySitters.Shifts.Commands
{
    public class EndShiftCommandTests
    {
        private readonly DatabaseContext _context;
        private readonly EndShiftCommand _command;

        public EndShiftCommandTests()
        {
            var provider = ServiceProviderFactory.Create();
            _context = provider.GetService<DatabaseContext>();
            _command = new EndShiftCommand(_context, new ShiftValidator());
        }
        
        [Fact]
        public async Task ShouldEndShift()
        {
            var sitter = _context.Add(ModelFactory.CreateSitter()).Entity;
            var shift = _context.Add(ModelFactory.CreateShift(sitter)).Entity;
            shift.EndTime = null;
            _context.SaveChanges();

            var endTime = new LocalDateTime(2018, 7, 1, 0, 0);
            var args = new EndShiftArgs(sitter.Id, shift.Id, endTime);
            await _command.Execute(args);

            Assert.Equal(endTime, shift.EndTime);
        }
        
        [Fact]
        public async Task ShouldHaveAmountCharged()
        {
            var sitter = _context.Add(ModelFactory.CreateSitter()).Entity;
            var shift = _context.Add(ModelFactory.CreateShift(
                sitter, 
                startTime: "7:00 PM".ToLocalDateTime(), 
                bedtime: "9:00 PM".ToLocalDateTime())
            ).Entity;
            
            shift.EndTime = null;
            _context.SaveChanges();

            var endTime = "12:00 AM".ToLocalDateTime().PlusDays(1);
            var args = new EndShiftArgs(sitter.Id, shift.Id, endTime);
            await _command.Execute(args);

            Assert.Equal(48, shift.AmountCharged);
        }
        
        [Fact]
        public async Task ShouldThrowEntityNotFoundWhenSitterIsNotFound()
        {
            var sitter = _context.Add(ModelFactory.CreateSitter()).Entity;
            var shift = _context.Add(ModelFactory.CreateShift(sitter)).Entity;
            _context.SaveChanges();

            var args = new EndShiftArgs(int.MaxValue, shift.Id, shift.EndTime.Value);
            await Assert.ThrowsAsync<EntityNotFoundException<Sitter>>(() => _command.Execute(args));
        }
        
        [Fact]
        public async Task ShouldThrowEntityNotFoundWhenShiftIsNotFound()
        {
            var sitter = _context.Add(ModelFactory.CreateSitter()).Entity;
            var shift = _context.Add(ModelFactory.CreateShift(sitter)).Entity;
            _context.SaveChanges();

            var args = new EndShiftArgs(sitter.Id, int.MaxValue, shift.EndTime.Value);
            await Assert.ThrowsAsync<EntityNotFoundException<Shift>>(() => _command.Execute(args));
        }
        
        [Fact]
        public async Task ShouldThrowValidationException()
        {
            var sitter = _context.Add(ModelFactory.CreateSitter()).Entity;
            var shift = _context.Add(ModelFactory.CreateShift(sitter)).Entity;
            _context.SaveChanges();

            var endTime = LocalDateTime.FromDateTime(DateTime.MinValue);
            var args = new EndShiftArgs(sitter.Id, shift.Id, endTime);
            await Assert.ThrowsAsync<ValidationException>(() => _command.Execute(args));
        }
    }
}