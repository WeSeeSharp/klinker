using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Entities;
using BabySitter.Core.BabySitters.Shifts.Entities;
using BabySitter.Core.BabySitters.Shifts.Validation;
using BabySitter.Core.General;
using BabySitter.Core.General.Validation;
using NodaTime;

namespace BabySitter.Core.BabySitters.Shifts.Commands
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
        private readonly DatabaseContext _context;
        private readonly IValidator<Shift> _validator;

        public EndShiftCommand(DatabaseContext context, IValidator<Shift> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task Execute(EndShiftArgs args)
        {
            if (_context.Find<Sitter>(args.SitterId) == null)
                throw new EntityNotFoundException<Sitter>();
            
            var shift = _context.GetById<Shift>(args.ShiftId);
            if (shift == null)
                throw new EntityNotFoundException<Shift>();

            shift.EndTime = args.EndTime;
            var result = await _validator.Validate(shift);
            if (result.Invalid)
                throw new ValidationException(result);
            
            await _context.SaveChangesAsync();
        }
    }
}