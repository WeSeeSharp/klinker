using System.Threading.Tasks;
using BabySitter.Core.Entities;
using BabySitter.Core.Storage;
using NodaTime;

namespace BabySitter.Core.Commands
{
    public class EndShiftArgs
    {
        public int SitterId { get; }
        public int ShiftId { get; }
        public LocalDateTime EndTime { get; }

        public EndShiftArgs(int sitterId, int shiftId, LocalDateTime endTime)
        {
            SitterId = sitterId;
            ShiftId = shiftId;
            EndTime = endTime;
        }

        public EndShiftArgs WithSitterId(int sitterId)
        {
            return new EndShiftArgs(sitterId, ShiftId, EndTime);
        }

        public EndShiftArgs WithShiftId(int shiftId)
        {
            return new EndShiftArgs(SitterId, shiftId, EndTime);
        }
    }
    
    public class EndShiftCommand : ICommand<EndShiftArgs>
    {
        private readonly BabySitterContext _context;

        public EndShiftCommand(BabySitterContext context)
        {
            _context = context;
        }

        public async Task Execute(EndShiftArgs args)
        {
            var shift = _context.GetById<Shift>(args.ShiftId);

            shift.EndTime = args.EndTime;
            await _context.SaveChangesAsync();
        }
    }
}