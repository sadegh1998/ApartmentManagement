using Application.Feature.Command.Unit.CreateUnit;
using Application.Feature.Command.Unit.EditUnit;
using Application.Feature.Query.Unit.GetAllUnits;
using Application.Feature.Query.Unit.GetUnitById;
using Application.Feature.Query.Unit.SearchUnit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ModisaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
       private readonly IMediator _mediator;

        public UnitController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [Route("GetAllUnitsAsync")]
        public async Task<IActionResult> GetAllUnitsAsync()
        {
            var query = new GetAllUnitsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetUnitByAsync")]
        public async Task<IActionResult> GetUnitByAsync(Guid Id)
        {
            var query = new GetUnitByIdQuery(Id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        [Route("CreateUnitAsync")]
        public async Task<IActionResult> CreateUnitAsync([FromBody] CreateUnitCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        [Route("EditUnitAsync")]
        public async Task<IActionResult> EditUnitAsync([FromBody] EditUnitCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPatch]
        [Route("SearchUnitAsync")]
        public async Task<IActionResult> SearchUnitAsync([FromBody] SearchUnitQuery command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
