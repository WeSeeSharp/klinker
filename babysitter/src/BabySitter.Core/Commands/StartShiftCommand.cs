using System.Threading.Tasks;
using BabySitter.Core.Entities;
using BabySitter.Core.Models;
using BabySitter.Core.Storage;
using NodaTime;

namespace BabySitter.Core.Commands
{
    public class StartShiftArgs
    {
        public int SitterId { get; }
        public LocalDateTime StartTime { get; }
        public LocalDateTime Bedtime { get; }

        public StartShiftArgs(int sitterId, LocalDateTime startTime, LocalDateTime bedtime)
        {
            SitterId = sitterId;
            StartTime = startTime;
            Bedtime = bedtime;
        }
        
        public StartShiftArgs WithId(int id)
        {
            return new StartShiftArgs(id, StartTime, Bedtime);
        }
    }
    
    public class StartShiftCommand : ICommandWithResult<StartShiftArgs, ShiftModel>
    {
        private readonly BabySitterContext _context;

        public StartShiftCommand(BabySitterContext context)
        {
            _context = context;
        }

        public async Task<ShiftModel> Execute(StartShiftArgs args)
        {
            var sitter = _context.GetById<Sitter>(args.SitterId); 
            var shift = new Shift
            {
                Bedtime = args.Bedtime,
                StartTime = args.StartTime,
                Sitter = sitter,
                HourlyRates = sitter.HourlyRates
            };
            _context.Add(shift);
            await _context.SaveChangesAsync();
            return shift.ToModel();
        }
    }
}