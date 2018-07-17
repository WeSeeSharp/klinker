using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Entities;
using BabySitter.Core.General;
using BabySitter.Core.General.Cqrs;
using BabySitter.Core.General.Validation;
using Microsoft.EntityFrameworkCore;

namespace BabySitter.Core.BabySitters.Commands
{
    public class UpdateBabySitterArgs : ICommandArgs
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public long HourlyRate { get; }
        public long HourlyRateAfterMidnight { get; }
        public long HourlyRateBetweenBedtimeAndMidnight { get; }

        public UpdateBabySitterArgs(int id,
            string firstName,
            string lastName,
            long hourlyRate,
            long hourlyRateBetweenBedtimeAndMidnight,
            long hourlyRateAfterMidnight)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            HourlyRate = hourlyRate;
            HourlyRateAfterMidnight = hourlyRateAfterMidnight;
            HourlyRateBetweenBedtimeAndMidnight = hourlyRateBetweenBedtimeAndMidnight;
        }

        public UpdateBabySitterArgs WithId(int id)
        {
            return new UpdateBabySitterArgs(
                id, 
                FirstName,
                LastName,
                HourlyRate,
                HourlyRateBetweenBedtimeAndMidnight, 
                HourlyRateAfterMidnight);
        }
    }

    public class UpdateBabySitterCommand : ICommandHandler<UpdateBabySitterArgs>
    {
        private readonly DatabaseContext _context;
        private readonly IValidator<Sitter> _validator;

        public UpdateBabySitterCommand(DatabaseContext context, IValidator<Sitter> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task Execute(UpdateBabySitterArgs args)
        {
            var sitter = await _context.FindAsync<Sitter>(args.Id);
            if (sitter == null)
                throw new EntityNotFoundException<Sitter>();
            
            sitter.FirstName = args.FirstName;
            sitter.LastName = args.LastName;
            sitter.HourlyRates.Standard = args.HourlyRate;
            sitter.HourlyRates.AfterMidnight = args.HourlyRateAfterMidnight;
            sitter.HourlyRates.BetweenBedtimeAndMidnight = args.HourlyRateBetweenBedtimeAndMidnight;

            var result = await _validator.Validate(sitter);
            if (result.Invalid)
                throw new ValidationException(result);
            
            await _context.SaveChangesAsync();
        }
    }
}