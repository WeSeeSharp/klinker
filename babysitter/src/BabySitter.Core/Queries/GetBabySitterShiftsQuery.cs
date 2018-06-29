using System.Linq;
using System.Threading.Tasks;
using BabySitter.Core.Entities;
using BabySitter.Core.Models;
using BabySitter.Core.Storage;
using Microsoft.EntityFrameworkCore;

namespace BabySitter.Core.Queries
{
    public class GetBabySitterShiftsArgs
    {
        public int BabySitterId { get; }

        public GetBabySitterShiftsArgs(int babySitterId)
        {
            BabySitterId = babySitterId;
        }
    }

    public class GetBabySitterShiftsQuery : IQueryHandler<GetBabySitterShiftsArgs, ShiftModel[]>
    {
        private readonly BabySitterContext _context;

        public GetBabySitterShiftsQuery(BabySitterContext context)
        {
            _context = context;
        }

        public async Task<ShiftModel[]> Execute(GetBabySitterShiftsArgs args)
        {
            return await _context.Shifts
                .Where(s => s.Sitter.Id == args.BabySitterId)
                .Select(Shift.ToModelExpression())
                .ToArrayAsync();
        }
    }
}