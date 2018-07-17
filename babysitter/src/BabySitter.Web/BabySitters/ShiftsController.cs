using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Shifts;
using BabySitter.Core.BabySitters.Shifts.Commands;
using BabySitter.Core.BabySitters.Shifts.Models;
using BabySitter.Core.BabySitters.Shifts.Queries;
using BabySitter.Core.General;
using BabySitter.Core.General.Cqrs;
using Microsoft.AspNetCore.Mvc;

namespace BabySitter.Web.BabySitters
{
    [Route("babysitters/{babySitterId:int}")]
    public class ShiftsController : Controller
    {
        private readonly IQueryBus _queryBus;
        private readonly ICommandBus _commandBus;

        public ShiftsController(
            IQueryBus queryBus,
            ICommandBus commandBus)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
        }

        [HttpGet("shifts")]
        public async Task<IActionResult> GetBabySitterShifts(int babySitterId)
        {
            var args = new GetBabySitterShiftsArgs(babySitterId);
            var models = await _queryBus.Execute<GetBabySitterShiftsArgs, ShiftModel[]>(args);
            return Ok(models);
        }
        
        [HttpGet("shifts/{shiftId:int}", Name = "GetBabySitterShift")]
        public async Task<IActionResult> GetBabySitterShift(int babySitterId, int shiftId)
        {
            var args = new GetBabySitterShiftByIdArgs(babySitterId, shiftId);
            var model = await _queryBus.Execute<GetBabySitterShiftByIdArgs, ShiftModel>(args);
            return Ok(model);
        }

        [HttpPost("startShift")]
        public async Task<IActionResult> StartShift(int babySitterId, [FromBody] StartShiftArgs args)
        {
            args = args.WithId(babySitterId);
            var model = await _commandBus.Execute<StartShiftArgs, ShiftModel>(args);
            return CreatedAtRoute("GetBabySitterShift", new {shiftId = model.Id, babySitterId = model.SitterId}, model);
        }

        [HttpPut("shifts/{shiftId:int}/endShift")]
        public async Task<IActionResult> EndShift(int babySitterId, int shiftId, [FromBody] EndShiftArgs args)
        {
            args = args.WithShiftId(shiftId)
                .WithSitterId(babySitterId);
            
            await _commandBus.Execute(args);
            return NoContent();
        }
    }
}