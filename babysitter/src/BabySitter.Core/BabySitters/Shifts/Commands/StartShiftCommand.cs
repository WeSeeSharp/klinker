using System.Linq;
using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Entities;
using BabySitter.Core.BabySitters.Shifts.Entities;
using BabySitter.Core.BabySitters.Shifts.Models;
using BabySitter.Core.General;
using BabySitter.Core.General.Validation;
using Microsoft.EntityFrameworkCore;
using NodaTime;

namespace BabySitter.Core.BabySitters.Shifts.Commands
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
        private readonly DatabaseContext _context;
        private readonly IValidator<Shift> _validator;

        public StartShiftCommand(DatabaseContext context, IValidator<Shift> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<ShiftModel> Execute(StartShiftArgs args)
        {
            var sitter = await _context.BabySitters
                .Include(s => s.Shifts)
                .SingleOrDefaultAsync(s => s.Id == args.SitterId);
            
            if (sitter == null)
                throw new EntityNotFoundException<Sitter>();
            
            var shift = new Shift
            {
                Bedtime = args.Bedtime,
                StartTime = args.StartTime,
                Sitter = sitter,
                HourlyRates = sitter.HourlyRates.Clone()
            };

            var result = await _validator.Validate(shift);
            if (result.Invalid)
                throw new ValidationException(result);

            _context.Add(shift);
            await _context.SaveChangesAsync();
            return shift.ToModel();
        }
    }
}