using System.Threading.Tasks;

namespace BabySitter.Core.Commands
{
    public interface ICommand<in TArgs>
    {
        Task Execute(TArgs args);
    }

    public interface ICommandWithResult<in TArgs, TResult>
    {
        Task<TResult> Execute(TArgs args);
    }
}