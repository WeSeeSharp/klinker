using System.Linq;
using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Shifts.Entities;
using BabySitter.Core.BabySitters.Shifts.Models;
using BabySitter.Core.General;
using Microsoft.EntityFrameworkCore;

namespace BabySitter.Core.BabySitters.Shifts.Queries
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
        private readonly DatabaseContext _context;

        public GetBabySitterShiftByIdQuery(DatabaseContext context)
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