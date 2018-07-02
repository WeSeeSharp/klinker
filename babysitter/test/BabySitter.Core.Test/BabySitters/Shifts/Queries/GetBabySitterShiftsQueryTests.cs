using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Shifts.Queries;
using BabySitter.Core.General;
using BabySitter.Core.Test.Utilties;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BabySitter.Core.Test.BabySitters.Shifts.Queries
{
    public class GetBabySitterShiftsQueryTests
    {
        private readonly DatabaseContext _context;
        private readonly GetBabySitterShiftsQuery _query;

        public GetBabySitterShiftsQueryTests()
        {
            var provider = ServiceProviderFactory.Create();
            _context = provider.GetService<DatabaseContext>();
            _query = new GetBabySitterShiftsQuery(_context);
        }
        
        [Fact]
        public async Task ShouldReturnShiftsForSitter()
        {
            var sitter = _context.Add(ModelFactory.CreateSitter()).Entity;
            _context.Add(ModelFactory.CreateShift(sitter));
            _context.Add(ModelFactory.CreateShift());
            _context.Add(ModelFactory.CreateShift(sitter));
            _context.Add(ModelFactory.CreateShift(sitter));
            _context.Add(ModelFactory.CreateShift());
            _context.SaveChanges();

            var args = new GetBabySitterShiftsArgs(sitter.Id);
            var models = await _query.Execute(args);
            Assert.Equal(3, models.Length);
        }
        
        [Fact]
        public async Task ShouldReturnEmptyShiftsWhenSitterIdDoesNotMatchAnySitters()
        {
            var sitter = _context.Add(ModelFactory.CreateSitter()).Entity;
            _context.Add(ModelFactory.CreateShift(sitter));
            _context.Add(ModelFactory.CreateShift(sitter));
            _context.Add(ModelFactory.CreateShift(sitter));
            _context.SaveChanges();

            var args = new GetBabySitterShiftsArgs(int.MaxValue);
            var models = await _query.Execute(args);
            Assert.Empty(models);
        }
        
        [Fact]
        public async Task ShouldReturnEmptyShiftsWhenSitterHasNoShifts()
        {
            var sitter = _context.Add(ModelFactory.CreateSitter()).Entity;
            _context.SaveChanges();

            var args = new GetBabySitterShiftsArgs(sitter.Id);
            var models = await _query.Execute(args);
            Assert.Empty(models);
        }
    }
}