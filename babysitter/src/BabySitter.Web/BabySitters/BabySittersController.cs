using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Commands;
using BabySitter.Core.BabySitters.Models;
using BabySitter.Core.BabySitters.Queries;
using BabySitter.Core.BabySitters.Shifts.Services;
using BabySitter.Core.General;
using BabySitter.Core.General.Cqrs;
using Microsoft.AspNetCore.Mvc;

namespace BabySitter.Web.BabySitters
{
    [Route("[controller]")]
    public class BabySittersController : Controller
    {
        private readonly IQueryBus _queryBus;
        private readonly ICommandBus _commandBus;
        private readonly NightlyChargeCalculator _calculator;

        public BabySittersController(IQueryBus queryBus, ICommandBus commandBus, NightlyChargeCalculator calculator)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
            _calculator = calculator;
        }

        [HttpGet(Name = "GetAllBabySitters")]
        public async Task<IActionResult> GetAll()
        {
            var items = await _queryBus.Execute<GetAllBabySittersArgs, SitterModel[]>(new GetAllBabySittersArgs());
            return Ok(items);
        }

        [HttpGet("{id:int}", Name = "GetBabySitterById")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await _queryBus.Execute<GetBabySitterByIdArgs, SitterModel>(new GetBabySitterByIdArgs(id));
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddBabySitter([FromBody] AddBabySitterArgs args)
        {
            var model = await _commandBus.Execute<AddBabySitterArgs, SitterModel>(args);
            return CreatedAtRoute("GetBabySitterById", new {id = model.Id}, model);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBabySitter(int id, [FromBody] UpdateBabySitterArgs args)
        {
            args = args.WithId(id);
            await _commandBus.Execute(args);
            return NoContent();
        }

        [HttpPost("nightlyCharge")]
        public IActionResult NightlyCharge([FromBody] NightlyChargeArgs args)
        {
            var total = _calculator.Calculate(args);
            return Ok(new TotalModel(total));
        }
    }
}