using System.Threading.Tasks;
using BabySitter.Core.General;
using Microsoft.EntityFrameworkCore;

namespace BabySitter.Core.BabySitters.Commands
{
    public class UpdateBabySitterArgs
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int HourlyRate { get; }
        public int HourlyRateAfterMidnight { get; }
        public int HourlyRateBetweenBedtimeAndMidnight { get; }

        public UpdateBabySitterArgs(int id,
            string firstName,
            string lastName,
            int hourlyRate,
            int hourlyRateBetweenBedtimeAndMidnight,
            int hourlyRateAfterMidnight)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            HourlyRate = hourlyRate;
            HourlyRateAfterMidnight = hourlyRateAfterMidnight;
            HourlyRateBetweenBedtimeAndMidnight = hourlyRateBetweenBedtimeAndMidnight;
        }

        public static UpdateBabySitterArgs WithId(int id, UpdateBabySitterArgs args)
        {
            return new UpdateBabySitterArgs(
                id, 
                args.FirstName,
                args.LastName,
                args.HourlyRate,
                args.HourlyRateBetweenBedtimeAndMidnight, args.HourlyRateAfterMidnight);
        }
    }

    public class UpdateBabySitterCommand : ICommand<UpdateBabySitterArgs>
    {
        private readonly DatabaseContext _context;

        public UpdateBabySitterCommand(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Execute(UpdateBabySitterArgs args)
        {
            var sitter = await _context.BabySitters.SingleAsync(b => b.Id == args.Id);
            sitter.FirstName = args.FirstName;
            sitter.LastName = args.LastName;
            sitter.HourlyRates.Standard = args.HourlyRate;
            sitter.HourlyRates.AfterMidnight = args.HourlyRateAfterMidnight;
            sitter.HourlyRates.BetweenBedtimeAndMidnight = args.HourlyRateBetweenBedtimeAndMidnight;
            await _context.SaveChangesAsync();
        }
    }
}