using System.Threading.Tasks;

namespace BabySitter.Core.General
{
    public interface IQueryHandler<in TArgs, TResult>
    {
        Task<TResult> Execute(TArgs args);
    }
}