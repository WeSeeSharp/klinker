using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BabySitter.Core.General.Cqrs
{
    public class CommandHandlerWithResultLoggingDecorator<TArgs, TResult> : ICommandHandlerWithResult<TArgs, TResult> 
        where TArgs : ICommandWithResultArgs<TResult>
    {
        private readonly ICommandHandlerWithResult<TArgs, TResult> _actual;
        private readonly ILogger _logger;

        public string CommandName => _actual.GetType().Name;
        
        public CommandHandlerWithResultLoggingDecorator(ICommandHandlerWithResult<TArgs, TResult> actual, ILogger logger)
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
                _logger.LogInformation($"{CommandName} took {stopWatch.ElapsedMilliseconds} ms");
            }
        }
    }
}