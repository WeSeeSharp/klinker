using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Entities;
using BabySitter.Core.BabySitters.Models;
using BabySitter.Core.General;
using BabySitter.Core.General.Validation;

namespace BabySitter.Core.BabySitters.Commands
{
    public class AddBabySitterArgs
    {
        public string FirstName { get; }
        public string LastName { get; }
        public long? HourlyRate { get; }
        public long? HourlyRateAfterMidnight { get; }
        public long? HourlyRateBetweenBedtimeAndMidnight { get; }

        public AddBabySitterArgs(string firstName,
            string lastName,
            long? hourlyRate = null,
            long? hourlyRateBetweenBedtimeAndMidnight = null,
            long? hourlyRateAfterMidnight = null)
        {
            FirstName = firstName;
            LastName = lastName;
            HourlyRate = hourlyRate;
            HourlyRateAfterMidnight = hourlyRateAfterMidnight;
            HourlyRateBetweenBedtimeAndMidnight = hourlyRateBetweenBedtimeAndMidnight;
        }
    }

    public class AddBabySitterCommand : ICommandWithResult<AddBabySitterArgs, SitterModel>
    {
        private readonly DatabaseContext _context;
        private readonly IValidator<Sitter> _validator;

        public AddBabySitterCommand(DatabaseContext context, IValidator<Sitter> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<SitterModel> Execute(AddBabySitterArgs args)
        {
            var sitter = CreateSitter(args);
            var result = await _validator.Validate(sitter);
            if (!result.IsValid)
                throw new ValidationException(result);
            
            _context.Add(sitter);
            await _context.SaveChangesAsync();
            return sitter.ToModel();
        }

        private static Sitter CreateSitter(AddBabySitterArgs args)
        {
            return new Sitter
            {
                FirstName = args.FirstName,
                LastName = args.LastName,
                HourlyRates = HourlyRates.FromRates(
                    args.HourlyRate.GetValueOrDefault(HourlyRates.StandardHourlyRate),
                    args.HourlyRateBetweenBedtimeAndMidnight.GetValueOrDefault(HourlyRates.StandardHourlyRateBetweenBedtimeAndMidnight),
                    args.HourlyRateAfterMidnight.GetValueOrDefault(HourlyRates.StandardHourlyRateAfterMidnight))
            };
        }
    }
}