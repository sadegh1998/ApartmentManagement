using Application.Feature.Command.Role.CreateRole;
using Application.Feature.Command.Role.DeleteRole;
using Application.Feature.Command.Role.EditRole;
using Application.Feature.Query.Role.GetAllRoles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ModisaApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllRoles")]
        public async Task<ActionResult<IEnumerable<RoleViewModel>>> GetAllRoles()
        {
            var result = await _mediator.Send(new GetAllRolesQuery());
            return Ok(result);
        }

        [HttpPost("CreateRole")]
        public async Task<ActionResult<Guid>> CreateRole([FromBody] CreateRoleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("EditRole")]
        public async Task<ActionResult<bool>> EditRole([FromBody] EditRoleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("DeleteRole/{id}")]
        public async Task<ActionResult<bool>> DeleteRole(Guid id)
        {
            var result = await _mediator.Send(new DeleteRoleCommand { Id = id });
            return Ok(result);
        }
    }
}
