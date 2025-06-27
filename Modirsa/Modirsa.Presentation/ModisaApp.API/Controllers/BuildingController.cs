using Application.Feature.Command.Building.CreateBuilding;
using Application.Feature.Command.Building.EditBuilding;
using Application.Feature.Query.Building.GetAllBuilding;
using Application.Feature.Query.Building.GetBuildingById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ModisaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BuildingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllBuilding")]
        public async Task<IActionResult> GetAllBuildingAsync()
        {
            var query = new GetAllBuildingQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetBuildingAsyncBy")]
        public async Task<IActionResult> GetBuildingAsyncBy(Guid Id)
        {
            var query = new GetBuildingByIdQuery(Id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        [Route("CreateNewBuilding")]
        public async Task<IActionResult> CreateNewBuilding([FromBody] CreateBuildingCommand command)
        {
            var result =await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        [Route("EditBuilding")]
        public async Task<IActionResult> EditBuildingAsync([FromBody] EditBuildingCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
