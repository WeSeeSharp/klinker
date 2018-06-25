using System.Threading.Tasks;
using BabySitter.Core.Storage;
using Microsoft.EntityFrameworkCore;

namespace BabySitter.Core.Commands
{
    public class UpdateBabySitterArgs
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int HourlyRate { get; }
        public int HourlyRateAfterMidnight { get; }
        public int HourlyRateBetweenBedtimeAndMidnight { get; }

        public UpdateBabySitterArgs(
            int id, 
            string firstName, 
            string lastName, 
            int hourlyRate,
            int hourlyRateAfterMidnight, 
            int hourlyRateBetweenBedtimeAndMidnight)
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
                args.HourlyRateAfterMidnight,
                args.HourlyRateBetweenBedtimeAndMidnight);
        }
    }

    public class UpdateBabySitterCommand : ICommand<UpdateBabySitterArgs>
    {
        private readonly BabySitterContext _context;

        public UpdateBabySitterCommand(BabySitterContext context)
        {
            _context = context;
        }

        public async Task Execute(UpdateBabySitterArgs args)
        {
            var sitter = await _context.BabySitters.SingleAsync(b => b.Id == args.Id);
            sitter.FirstName = args.FirstName;
            sitter.LastName = args.LastName;
            sitter.HourlyRate = args.HourlyRate;
            sitter.HourlyRateAfterMidnight = args.HourlyRateAfterMidnight;
            sitter.HourlyRateBetweenBedtimeAndMidnight = args.HourlyRateBetweenBedtimeAndMidnight;
            await _context.SaveChangesAsync();
        }
    }
}