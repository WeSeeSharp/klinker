using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Shifts.Queries;
using BabySitter.Core.General;
using BabySitter.Core.Test.Utilties;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BabySitter.Core.Test.BabySitters.Shifts.Queries
{
    public class GetBabySitterShiftByIdQueryTests
    {
        private readonly DatabaseContext _context;
        private readonly GetBabySitterShiftByIdQuery _query;

        public GetBabySitterShiftByIdQueryTests()
        {
            var provider = ServiceProviderFactory.Create();
            _context = provider.GetService<DatabaseContext>();
            _query = new GetBabySitterShiftByIdQuery(_context);
        }
        
        [Fact]
        public async Task ShouldReturnShiftForBabySitter()
        {
            var sitter = _context.Add(ModelFactory.CreateSitter()).Entity;
            _context.Add(ModelFactory.CreateShift(sitter));
            var shift = _context.Add(ModelFactory.CreateShift(sitter)).Entity;
            _context.Add(ModelFactory.CreateShift(sitter));
            _context.SaveChanges();

            var args = new GetBabySitterShiftByIdArgs(sitter.Id, shift.Id);
            var model = await _query.Execute(args);
            Assert.Equal(shift.Id, model.Id);
            Assert.Equal(shift.Sitter.Id, model.SitterId);
            Assert.Equal(shift.Bedtime, model.Bedtime);
            Assert.Equal(shift.EndTime, model.EndTime);
            Assert.Equal(shift.StartTime, model.StartTime);
            Assert.Equal(shift.HourlyRates.Standard, model.HourlyRate);
            Assert.Equal(shift.HourlyRates.BetweenBedtimeAndMidnight, model.HourlyRateBetweenBedtimeAndMidnight);
            Assert.Equal(shift.HourlyRates.AfterMidnight, model.HourlyRateAfterMidnight);
        }
        
        [Fact]
        public async Task ShouldReturnNullWhenSitterIdDoesNotMatch()
        {
            var sitter = _context.Add(ModelFactory.CreateSitter()).Entity;
            var shift = _context.Add(ModelFactory.CreateShift(sitter)).Entity;
            _context.SaveChanges();
            
            var args = new GetBabySitterShiftByIdArgs(int.MaxValue, shift.Id);
            var model = await _query.Execute(args);
            Assert.Null(model);
        }
        
        [Fact]
        public async Task ShouldReturnNullWhenShiftIdDoesNotMatch()
        {
            var sitter = _context.Add(ModelFactory.CreateSitter()).Entity;
            var shift = _context.Add(ModelFactory.CreateShift(sitter)).Entity;
            _context.SaveChanges();
            
            var args = new GetBabySitterShiftByIdArgs(sitter.Id, int.MaxValue);
            var model = await _query.Execute(args);
            Assert.Null(model);
            
        }
    }
}