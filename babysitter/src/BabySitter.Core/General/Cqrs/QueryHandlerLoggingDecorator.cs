using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BabySitter.Core.General.Cqrs
{
    public class QueryHandlerLoggingDecorator<TArgs, TResult> : IQueryHandler<TArgs, TResult> 
        where TArgs : IQueryArgs<TResult>
    {
        private readonly IQueryHandler<TArgs, TResult> _actual;
        private readonly ILogger _logger;

        public string QueryName => _actual.GetType().Name;

        public QueryHandlerLoggingDecorator(IQueryHandler<TArgs, TResult> actual, ILogger logger)
        {
            _actual = actual;
            _logger = logger;
        }

        public async Task<TResult> Execute(TArgs args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {
                return await _actual.Execute(args);
            }
            finally
            {
                stopWatch.Stop();
                _logger.LogInformation($"{QueryName} took {stopWatch.ElapsedMilliseconds} ms");
            }
        }
    }
}