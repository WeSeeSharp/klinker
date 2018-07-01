using System.Linq;
using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Entities;
using BabySitter.Core.BabySitters.Models;
using BabySitter.Core.General;
using Microsoft.EntityFrameworkCore;

namespace BabySitter.Core.BabySitters.Queries
{
    public class GetBabySitterByIdArgs
    {
        public int Id { get; }

        public GetBabySitterByIdArgs(int id)
        {
            Id = id;
        }
    }
    
    public class GetBabySitterByIdQuery : IQueryHandler<GetBabySitterByIdArgs, SitterModel>
    {
        private readonly DatabaseContext _context;

        public GetBabySitterByIdQuery(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<SitterModel> Execute(GetBabySitterByIdArgs args)
        {
            return await _context.BabySitters
                .Select(Sitter.ToModelExpression())
                .SingleOrDefaultAsync(b => b.Id == args.Id);
        }
    }
}