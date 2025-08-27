using Application.Feature.Command.Permission.CreatePermission;
using Application.Feature.Query.Permission.GetAllPermissions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ModisaApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllPermissions")]
        public async Task<ActionResult<IEnumerable<PermissionViewModel>>> GetAllPermissions()
        {
            var result = await _mediator.Send(new GetAllPermissionsQuery());
            return Ok(result);
        }

        [HttpPost("CreatePermission")]
        public async Task<ActionResult<Guid>> CreatePermission([FromBody] CreatePermissionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
