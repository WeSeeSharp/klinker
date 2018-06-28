using System.Data.Common;
using System.Threading.Tasks;
using BabySitter.Core.Entities;
using BabySitter.Core.Models;
using BabySitter.Core.Storage;

namespace BabySitter.Core.Commands
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
            int? hourlyRateAfterMidnight = null,
            int? hourlyRateBetweenBedtimeAndMidnight = null)
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
        private readonly BabySitterContext _context;

        public AddBabySitterCommand(BabySitterContext context)
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