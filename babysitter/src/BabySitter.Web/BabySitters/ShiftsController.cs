using System.Threading.Tasks;
using BabySitter.Core.Commands;
using BabySitter.Core.Models;
using BabySitter.Core.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BabySitter.Web.BabySitters
{
    [Route("babysitters/{babySitterId:int}")]
    public class ShiftsController : Controller
    {
        private readonly IQueryHandler<GetBabySitterShiftsArgs, ShiftModel[]> _getShiftsQuery;
        private readonly IQueryHandler<GetBabySitterShiftByIdArgs, ShiftModel> _getShiftByIdQuery;
        private readonly ICommand<EndShiftArgs> _endShiftCommand;
        private readonly ICommandWithResult<StartShiftArgs, ShiftModel> _startShiftCommand;

        public ShiftsController(
            IQueryHandler<GetBabySitterShiftsArgs, ShiftModel[]> getShiftsQuery,
            IQueryHandler<GetBabySitterShiftByIdArgs, ShiftModel> getShiftByIdQuery,
            ICommand<EndShiftArgs> endShiftCommand,
            ICommandWithResult<StartShiftArgs, ShiftModel> startShiftCommand)
        {
            _getShiftsQuery = getShiftsQuery;
            _getShiftByIdQuery = getShiftByIdQuery;
            _endShiftCommand = endShiftCommand;
            _startShiftCommand = startShiftCommand;
        }

        [HttpGet("shifts")]
        public async Task<IActionResult> GetBabySitterShifts(int babySitterId)
        {
            var args = new GetBabySitterShiftsArgs(babySitterId);
            var models = await _getShiftsQuery.Execute(args);
            return Ok(models);
        }
        
        [HttpGet("shifts/{shiftId:int}", Name = "GetBabySitterShift")]
        public async Task<IActionResult> GetBabySitterShift(int babySitterId, int shiftId)
        {
            var args = new GetBabySitterShiftByIdArgs(babySitterId, shiftId);
            var model = await _getShiftByIdQuery.Execute(args);
            return Ok(model);
        }

        [HttpPost("startShift")]
        public async Task<IActionResult> StartShift(int babySitterId, [FromBody] StartShiftArgs args)
        {
            args = args.WithId(babySitterId);
            var model = await _startShiftCommand.Execute(args);
            return CreatedAtRoute("GetBabySitterShift", new {shiftId = model.Id, babySitterId = model.SitterId}, model);
        }

        [HttpPut("shifts/{shiftId:int}/endShift")]
        public async Task<IActionResult> EndShift(int babySitterId, int shiftId, [FromBody] EndShiftArgs args)
        {
            args = args.WithShiftId(shiftId)
                .WithSitterId(babySitterId);
            
            await _endShiftCommand.Execute(args);
            return NoContent();
        }
    }
}