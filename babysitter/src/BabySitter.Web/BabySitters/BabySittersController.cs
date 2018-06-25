using System.Threading.Tasks;
using BabySitter.Core;
using BabySitter.Core.Commands;
using BabySitter.Core.Models;
using BabySitter.Core.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BabySitter.Web.BabySitters
{
    [Route("[controller]")]
    public class BabySittersController : Controller
    {
        private readonly IQueryHandler<GetAllBabySittersArgs, SitterModel[]> _getAllQuery;
        private readonly IQueryHandler<GetBabySitterByIdArgs, SitterModel> _getByIdQuery;
        private readonly ICommandWithResult<AddBabySitterArgs, SitterModel> _addBabySitterCommand;
        private readonly NightlyChargeCalculator _calculator;

        public BabySittersController(
            IQueryHandler<GetAllBabySittersArgs, SitterModel[]> getAllQuery,
            IQueryHandler<GetBabySitterByIdArgs, SitterModel> getByIdQuery,
            ICommandWithResult<AddBabySitterArgs, SitterModel> addBabySitterCommand,
            NightlyChargeCalculator calculator)
        {
            _getAllQuery = getAllQuery;
            _getByIdQuery = getByIdQuery;
            _addBabySitterCommand = addBabySitterCommand;
            _calculator = calculator;
        }

        [HttpGet(Name = "GetAllBabySitters")]
        public async Task<IActionResult> GetAll()
        {
            var items = await _getAllQuery.Execute(new GetAllBabySittersArgs());
            return Ok(items);
        }

        [HttpGet("{id:int}", Name = "GetBabySitterById")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await _getByIdQuery.Execute(new GetBabySitterByIdArgs(id));
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddBabySitter([FromBody] AddBabySitterArgs args)
        {
            var model = await _addBabySitterCommand.Execute(args);
            return CreatedAtRoute("GetBabySitterById", new {id = model.Id}, model);
        }

        [HttpPost("nightlyCharge")]
        public IActionResult NightlyCharge([FromBody] NightlyChargeParameters parameters)
        {
            var total = _calculator.Calculate(parameters);
            return Ok(new TotalModel(total));
        }
    }
}