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
        private readonly IQueryHandler<GetBabySitterShiftByIdArgs, ShiftModel> _getShiftByIdQuery;
        private readonly ICommandWithResult<AddBabySitterArgs, SitterModel> _addBabySitterCommand;
        private readonly ICommand<UpdateBabySitterArgs> _updateBabySitterCommand;
        private readonly ICommand<EndShiftArgs> _endShiftCommand;
        private readonly ICommandWithResult<StartShiftArgs, ShiftModel> _startShiftCommand;
        private readonly NightlyChargeCalculator _calculator;

        public BabySittersController(IQueryHandler<GetAllBabySittersArgs, SitterModel[]> getAllQuery,
            IQueryHandler<GetBabySitterByIdArgs, SitterModel> getByIdQuery,
            ICommandWithResult<AddBabySitterArgs, SitterModel> addBabySitterCommand,
            ICommand<UpdateBabySitterArgs> updateBabySitterCommand,
            ICommandWithResult<StartShiftArgs, ShiftModel> startShiftCommand,
            IQueryHandler<GetBabySitterShiftByIdArgs, ShiftModel> getShiftByIdQuery,
            ICommand<EndShiftArgs> endShiftCommand,
            NightlyChargeCalculator calculator)
        {
            _getAllQuery = getAllQuery;
            _getByIdQuery = getByIdQuery;
            _addBabySitterCommand = addBabySitterCommand;
            _startShiftCommand = startShiftCommand;
            _updateBabySitterCommand = updateBabySitterCommand;
            _getShiftByIdQuery = getShiftByIdQuery;
            _endShiftCommand = endShiftCommand;
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

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBabySitter(int id, [FromBody] UpdateBabySitterArgs args)
        {
            args = UpdateBabySitterArgs.WithId(id, args);
            await _updateBabySitterCommand.Execute(args);
            return NoContent();
        }

        [HttpGet("{babySitterId:int}/shifts/{shiftId:int}", Name = "GetBabySitterShift")]
        public async Task<IActionResult> GetBabySitterShift(int babySitterId, int shiftId)
        {
            var args = new GetBabySitterShiftByIdArgs(babySitterId, shiftId);
            var model = await _getShiftByIdQuery.Execute(args);
            return Ok(model);
        }

        [HttpPost("{id:int}/startShift")]
        public async Task<IActionResult> StartShift(int id, [FromBody] StartShiftArgs args)
        {
            args = StartShiftArgs.WithId(id, args);
            var model = await _startShiftCommand.Execute(args);
            return CreatedAtRoute("GetBabySitterShift", new {shiftId = model.Id, babySitterId = model.SitterId}, model);
        }

        [HttpPut("{babySitterId:int}/shifts/{shiftId:int}/endShift")]
        public async Task<IActionResult> EndShift(int babySitterId, int shiftId, [FromBody] EndShiftArgs args)
        {
            args = EndShiftArgs.WithShiftId(shiftId, args);
            args = EndShiftArgs.WithSitterId(babySitterId, args);
            await _endShiftCommand.Execute(args);
            return NoContent();
        }

        [HttpPost("nightlyCharge")]
        public IActionResult NightlyCharge([FromBody] NightlyChargeParameters parameters)
        {
            var total = _calculator.Calculate(parameters);
            return Ok(new TotalModel(total));
        }
    }
}