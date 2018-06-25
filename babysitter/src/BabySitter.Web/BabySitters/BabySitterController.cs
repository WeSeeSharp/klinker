using System.Linq;
using System.Threading.Tasks;
using BabySitter.Core;
using BabySitter.Web.BabySitters.Models;
using BabySitter.Web.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabySitter.Web.BabySitters
{
    [Route("babySitters")]
    public class BabySitterController : Controller
    {
        private readonly NightlyChargeCalculator _calculator;
        private readonly BabySitterContext _context;

        public BabySitterController(NightlyChargeCalculator calculator, BabySitterContext context)
        {
            _calculator = calculator;
            _context = context;
        }

        [HttpGet]
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

        [HttpPost("nightlyCharge")]
        public IActionResult NightlyCharge([FromBody] NightlyChargeParameters parameters)
        {
            var total = _calculator.Calculate(parameters);
            return Ok(new TotalModel(total));
        }
    }
}