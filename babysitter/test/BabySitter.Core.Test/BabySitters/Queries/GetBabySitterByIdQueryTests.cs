using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Queries;
using BabySitter.Core.General;
using BabySitter.Core.Test.Utilties;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BabySitter.Core.Test.BabySitters.Queries
{
    public class GetBabySitterByIdQueryTests
    {
        private readonly DatabaseContext _context;
        private readonly GetBabySitterByIdQuery _query;

        public GetBabySitterByIdQueryTests()
        {
            var provider = ServiceProviderFactory.Create();
            _context = provider.GetService<DatabaseContext>();
            _query = new GetBabySitterByIdQuery(_context);
        }
        
        [Fact]
        public async Task ShouldReturnBabySitterWithId()
        {
            _context.Add(ModelFactory.CreateSitter());
            var sitter = _context.Add(ModelFactory.CreateSitter()).Entity;
            _context.Add(ModelFactory.CreateSitter());
            _context.SaveChanges();

            var model = await _query.Execute(new GetBabySitterByIdArgs(sitter.Id));
            Assert.Equal(sitter.Id, model.Id);
            Assert.Equal(sitter.FirstName, model.FirstName);
            Assert.Equal(sitter.LastName, model.LastName);
            Assert.Equal(sitter.HourlyRates.Standard, model.HourlyRate);
            Assert.Equal(sitter.HourlyRates.BetweenBedtimeAndMidnight, model.HourlyRateBetweenBedtimeAndMidnight);
            Assert.Equal(sitter.HourlyRates.AfterMidnight, model.HourlyRateAfterMidnight);
        }
        
        [Fact]
        public async Task ShouldReturnNullWhenSitterIsNotFound()
        {
            var model = await _query.Execute(new GetBabySitterByIdArgs(int.MaxValue));
            Assert.Null(model);
        }
    }
}