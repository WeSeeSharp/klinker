using BabySitter.Core;
using Microsoft.AspNetCore.Mvc;

namespace BabySitter.Web.BabySitters
{
    public class BabySitterController : Controller
    {
        private readonly NightlyChargeCalculator _calculator;

        public BabySitterController(NightlyChargeCalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpPost("nightlyCharge")]
        public IActionResult NightlyCharge([FromBody] NightlyChargeParameters parameters)
        {
            var total = _calculator.Calculate(parameters);
            return Ok(new TotalModel(total));
        }
    }
}