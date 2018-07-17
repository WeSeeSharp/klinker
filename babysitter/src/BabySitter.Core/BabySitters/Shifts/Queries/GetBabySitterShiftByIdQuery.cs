using System.Linq;
using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Shifts.Entities;
using BabySitter.Core.BabySitters.Shifts.Models;
using BabySitter.Core.General;
using BabySitter.Core.General.Cqrs;
using Microsoft.EntityFrameworkCore;

namespace BabySitter.Core.BabySitters.Shifts.Queries
{
    public class GetBabySitterShiftByIdArgs : IQueryArgs<ShiftModel>
    {
        public int SitterId { get; }
        public int ShiftId { get; }

        public GetBabySitterShiftByIdArgs(int sitterId, int shiftId)
        {
            SitterId = sitterId;
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
                    .Include(s => s.HourlyRates)
                .Where(s => s.Id == args.ShiftId)
                .Where(s => s.Sitter.Id == args.SitterId)
                .Select(Shift.ToModelExpression())
                .SingleOrDefaultAsync();
        }
    }
}