using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BabySitter.Core.General.Cqrs
{
    public interface IQueryBus
    {
        Task<TResult> Execute<TArgs, TResult>(TArgs args)
            where TArgs : IQueryArgs<TResult>;
    }
    
    public class QueryBus : IQueryBus
    {
        private readonly IServiceProvider _provider;
        private readonly ILogger _logger;

        public QueryBus(IServiceProvider provider, ILogger<QueryBus> logger)
        {
            _provider = provider;
            _logger = logger;
        }

        public async Task<TResult> Execute<TArgs, TResult>(TArgs args) 
            where TArgs : IQueryArgs<TResult>
        {
            var query = _provider.GetService<IQueryHandler<TArgs, TResult>>();
            var decorated = new QueryHandlerLoggingDecorator<TArgs, TResult>(query, _logger);
            return await decorated.Execute(args);
        }
    }
}