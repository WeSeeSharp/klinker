using System.Threading.Tasks;

namespace BabySitter.Core.General.Cqrs
{
    public interface IQueryArgs<TResult>
    {
        
    }
    
    public interface IQueryHandler<in TArgs, TResult>
        where TArgs : IQueryArgs<TResult>
    {
        Task<TResult> Execute(TArgs args);
    }
}