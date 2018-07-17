using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BabySitter.Core.General.Cqrs
{
    public class CommandHandlerLoggingDecorator<TCommandArgs> : ICommandHandler<TCommandArgs> 
        where TCommandArgs : ICommandArgs
    {
        private readonly ICommandHandler<TCommandArgs> _actual;
        private readonly ILogger _logger;

        public string CommandName => _actual.GetType().Name;
        
        public CommandHandlerLoggingDecorator(ICommandHandler<TCommandArgs> actual, ILogger logger)
        {
            _actual = actual;
            _logger = logger;
        }

        public async Task Execute(TCommandArgs args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {
                await _actual.Execute(args);
            }
            finally
            {
                stopWatch.Stop();
                _logger.LogInformation($"{CommandName} took {stopWatch.ElapsedMilliseconds} ms");
            }
        }
    }
}