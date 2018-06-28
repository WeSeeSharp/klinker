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

        public static EndShiftArgs WithSitterId(int sitterId, EndShiftArgs args)
        {
            return new EndShiftArgs(sitterId, args.ShiftId, args.EndTime);
        }

        public static EndShiftArgs WithShiftId(int shiftId, EndShiftArgs args)
        {
            return new EndShiftArgs(args.SitterId, shiftId, args.EndTime);
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