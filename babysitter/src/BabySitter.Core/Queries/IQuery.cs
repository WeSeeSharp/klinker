using System.Threading.Tasks;

namespace BabySitter.Core.Queries
{
    public interface IQueryHandler<in TArgs, TResult>
    {
        Task<TResult> Execute(TArgs args);
    }
}