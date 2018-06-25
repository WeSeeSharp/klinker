using System.Threading.Tasks;
using BabySitter.Core.Models;
using BabySitter.Core.Storage;

namespace BabySitter.Core.Commands
{
    public class AddBabySitterArgs
    {
        public string FirstName { get; }
        public string LastName { get; }

        public AddBabySitterArgs(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
    
    public class AddBabySitterCommand : ICommandWithResult<AddBabySitterArgs, BabySitterModel>
    {
        private readonly BabySitterContext _context;

        public AddBabySitterCommand(BabySitterContext context)
        {
            _context = context;
        }

        public async Task<BabySitterModel> Execute(AddBabySitterArgs args)
        {
            var babySitter = new Entities.BabySitter
            {
                FirstName = args.FirstName,
                LastName = args.LastName
            };
            _context.Add(babySitter);
            await _context.SaveChangesAsync();
            return babySitter.ToModel();
        }
    }
}