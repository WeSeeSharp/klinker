using System.Linq;
using System.Threading.Tasks;
using BabySitter.Core.Models;
using BabySitter.Core.Storage;
using Microsoft.EntityFrameworkCore;

namespace BabySitter.Core.Queries
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
        private readonly BabySitterContext _context;

        public GetBabySitterByIdQuery(BabySitterContext context)
        {
            _context = context;
        }

        public async Task<SitterModel> Execute(GetBabySitterByIdArgs args)
        {
            return await _context.BabySitters
                .Select(Entities.Sitter.ToModelExpression())
                .SingleAsync(b => b.Id == args.Id);
        }
    }
}