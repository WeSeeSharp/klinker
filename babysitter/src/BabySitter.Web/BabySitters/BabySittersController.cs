using System.Linq;
using System.Threading.Tasks;
using BabySitter.Core;
using BabySitter.Web.BabySitters.Models;
using BabySitter.Web.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabySitter.Web.BabySitters
{
    [Route("[controller]")]
    public class BabySittersController : Controller
    {
        private readonly NightlyChargeCalculator _calculator;
        private readonly BabySitterContext _context;

        public BabySittersController(NightlyChargeCalculator calculator, BabySitterContext context)
        {
            _calculator = calculator;
            _context = context;
        }

        [HttpGet(Name = "GetAllBabySitters")]
        public async Task<IActionResult> GetAll()
        {
            var items = await _context.BabySitters
                .Select(b => new BabySitterItemModel
                {
                    FirstName = b.FirstName,
                    LastName = b.LastName,
                    Id = b.Id
                }).ToArrayAsync();
            
            return Ok(items);
        }

        [HttpGet("{id:int}", Name = "GetBabySitterById")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await _context.BabySitters
                .Where(b => b.Id == id)
                .Select(b => new BabySitterModel
                {
                    FirstName = b.FirstName,
                    LastName = b.LastName
                }).SingleAsync();

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddBabySitter([FromBody] AddBabySitterModel model)
        {
            var babySitter = new Entities.BabySitter {FirstName = model.FirstName, LastName = model.LastName};
            _context.Add(babySitter);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetBabySitterById", new {id = babySitter.Id}, babySitter);
        }

        [HttpPost("nightlyCharge")]
        public IActionResult NightlyCharge([FromBody] NightlyChargeParameters parameters)
        {
            var total = _calculator.Calculate(parameters);
            return Ok(new TotalModel(total));
        }
    }
}