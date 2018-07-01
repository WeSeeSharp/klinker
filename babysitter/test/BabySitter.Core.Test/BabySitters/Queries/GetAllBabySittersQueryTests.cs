using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Queries;
using BabySitter.Core.General;
using BabySitter.Core.Test.Utilties;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BabySitter.Core.Test.BabySitters.Queries
{
    public class GetAllBabySittersQueryTests
    {
        private readonly DatabaseContext _context;
        private readonly GetAllBabySittersQuery _query;

        public GetAllBabySittersQueryTests()
        {
            var provider = ServiceProviderFactory.Create();
            _context = provider.GetService<DatabaseContext>();
            _query = new GetAllBabySittersQuery(_context);
        }
        
        [Fact]
        public async Task ShouldGetAllSitters()
        {
            _context.Add(ModelFactory.CreateSitter());
            _context.Add(ModelFactory.CreateSitter());
            _context.Add(ModelFactory.CreateSitter());
            _context.SaveChanges();

            var models = await _query.Execute(new GetAllBabySittersArgs());
            Assert.Equal(3, models.Length);
        }
        
        [Fact]
        public async Task ShouldPopulateSitter()
        {
            var sitter = ModelFactory.CreateSitter();
            _context.Add(sitter);
            _context.SaveChanges();

            var models = await _query.Execute(new GetAllBabySittersArgs());
            Assert.Equal(sitter.Id, models[0].Id);
            Assert.Equal(sitter.FirstName, models[0].FirstName);
            Assert.Equal(sitter.LastName, models[0].LastName);
            Assert.Equal(sitter.HourlyRates.Standard, models[0].HourlyRate);
            Assert.Equal(sitter.HourlyRates.BetweenBedtimeAndMidnight, models[0].HourlyRateBetweenBedtimeAndMidnight);
            Assert.Equal(sitter.HourlyRates.AfterMidnight, models[0].HourlyRateAfterMidnight);
        }
    }
}