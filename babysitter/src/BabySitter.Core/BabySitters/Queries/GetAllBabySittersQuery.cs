using System.Linq;
using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Entities;
using BabySitter.Core.BabySitters.Models;
using BabySitter.Core.General;
using BabySitter.Core.General.Cqrs;
using Microsoft.EntityFrameworkCore;

namespace BabySitter.Core.BabySitters.Queries
{
    public class GetAllBabySittersArgs : IQueryArgs<SitterModel[]>
    {
        
    }
    
    public class GetAllBabySittersQuery : IQueryHandler<GetAllBabySittersArgs, SitterModel[]>
    {
        private readonly DatabaseContext _context;

        public GetAllBabySittersQuery(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<SitterModel[]> Execute(GetAllBabySittersArgs args)
        {
            return await _context.BabySitters
                .Select(Sitter.ToModelExpression())
                .ToArrayAsync();
        }
    }
}