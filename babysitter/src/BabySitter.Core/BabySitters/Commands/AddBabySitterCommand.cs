using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Entities;
using BabySitter.Core.BabySitters.Models;
using BabySitter.Core.General;

namespace BabySitter.Core.BabySitters.Commands
{
    public class AddBabySitterArgs
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int? HourlyRate { get; }
        public int? HourlyRateAfterMidnight { get; }
        public int? HourlyRateBetweenBedtimeAndMidnight { get; }

        public AddBabySitterArgs(string firstName,
            string lastName,
            int? hourlyRate = null,
            int? hourlyRateBetweenBedtimeAndMidnight = null,
            int? hourlyRateAfterMidnight = null)
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

        public AddBabySitterCommand(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<SitterModel> Execute(AddBabySitterArgs args)
        {
            var babySitter = new Sitter
            {
                FirstName = args.FirstName,
                LastName = args.LastName,
                HourlyRates = HourlyRates.FromRates(
                    args.HourlyRate.GetValueOrDefault(HourlyRates.StandardHourlyRate),
                    args.HourlyRateBetweenBedtimeAndMidnight.GetValueOrDefault(HourlyRates.StandardHourlyRateBetweenBedtimeAndMidnight),
                    args.HourlyRateAfterMidnight.GetValueOrDefault(HourlyRates.StandardHourlyRateAfterMidnight))
            };
            _context.Add(babySitter);
            await _context.SaveChangesAsync();
            return babySitter.ToModel();
        }
    }
}