using System.Threading.Tasks;

namespace BabySitter.Core.General.Cqrs
{
    public interface ICommandArgs
    {
        
    }
    
    public interface ICommandHandler<in TArgs>
        where TArgs : ICommandArgs
    {
        Task Execute(TArgs args);
    }

    public interface ICommandWithResultArgs<TResult>
    {
        
    }
    
    public interface ICommandHandlerWithResult<in TArgs, TResult>
        where TArgs : ICommandWithResultArgs<TResult>
    {
        Task<TResult> Execute(TArgs args);
    }
}