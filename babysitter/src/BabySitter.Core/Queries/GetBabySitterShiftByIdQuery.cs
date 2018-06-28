using System.Linq;
using System.Threading.Tasks;
using BabySitter.Core.Entities;
using BabySitter.Core.Models;
using BabySitter.Core.Storage;
using Microsoft.EntityFrameworkCore;

namespace BabySitter.Core.Queries
{
    public class GetBabySitterShiftByIdArgs
    {
        public int BabySitterId { get; }
        public int ShiftId { get; }

        public GetBabySitterShiftByIdArgs(int babySitterId, int shiftId)
        {
            BabySitterId = babySitterId;
            ShiftId = shiftId;
        }
    }
    
    public class GetBabySitterShiftByIdQuery : IQueryHandler<GetBabySitterShiftByIdArgs, ShiftModel>
    {
        private readonly BabySitterContext _context;

        public GetBabySitterShiftByIdQuery(BabySitterContext context)
        {
            _context = context;
        }

        public async Task<ShiftModel> Execute(GetBabySitterShiftByIdArgs args)
        {
            return await _context.Shifts
                .Where(s => s.Id == args.ShiftId)
                .Where(s => s.Sitter.Id == args.BabySitterId)
                .Select(Shift.ToModelExpression())
                .SingleAsync();
        }
    }
}