using System.Threading.Tasks;

namespace BabySitter.Core.General
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