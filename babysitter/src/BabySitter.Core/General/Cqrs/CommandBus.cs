using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BabySitter.Core.General.Cqrs
{
    public interface ICommandBus
    {
        Task Execute<TArgs>(TArgs args)
            where TArgs : ICommandArgs;
        
        Task<TResult> Execute<TArgs, TResult>(TArgs args)
            where TArgs : ICommandWithResultArgs<TResult>;
    }
    
    public class CommandBus : ICommandBus
    {
        private readonly IServiceProvider _provider;
        private readonly ILogger _logger;

        public CommandBus(IServiceProvider provider, ILogger<CommandBus> logger)
        {
            _provider = provider;
            _logger = logger;
        }

        public async Task Execute<TArgs>(TArgs args) 
            where TArgs : ICommandArgs
        {
            var command = _provider.GetService<ICommandHandler<TArgs>>();
            var decorated = new CommandHandlerLoggingDecorator<TArgs>(command, _logger);
            await decorated.Execute(args);
        }

        public async Task<TResult> Execute<TArgs, TResult>(TArgs args) 
            where TArgs : ICommandWithResultArgs<TResult>
        {
            var command = _provider.GetService<ICommandHandlerWithResult<TArgs, TResult>>();
            var decorated = new CommandHandlerWithResultLoggingDecorator<TArgs, TResult>(command, _logger);
            return await decorated.Execute(args);
        }
    }
}