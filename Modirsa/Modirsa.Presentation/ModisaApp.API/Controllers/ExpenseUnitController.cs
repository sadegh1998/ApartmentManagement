using Application.Feature.Command.ExpenseUnit.CreateExpenseUnit;
using Application.Feature.Command.ExpenseUnit.EditExpenseUnit;
using Application.Feature.Command.ExpenseUnit.DeleteExpenseUnit;
using Application.Feature.Query.ExpenseUnit.GetAllExpenseUnits;
using Application.Feature.Query.ExpenseUnit.GetExpenseUnitById;
using Application.Feature.Query.ExpenseUnit.GetExpenseUnitsByExpenseId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ModisaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseUnitController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpenseUnitController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllExpenseUnits")]
        public async Task<IActionResult> GetAllExpenseUnitsAsync()
        {
            var query = new GetAllExpenseUnitsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetExpenseUnitById")]
        public async Task<IActionResult> GetExpenseUnitByIdAsync(Guid id)
        {
            var query = new GetExpenseUnitByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetExpenseUnitsByExpenseId")]
        public async Task<IActionResult> GetExpenseUnitsByExpenseIdAsync(Guid expenseId)
        {
            var query = new GetExpenseUnitsByExpenseIdQuery(expenseId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateExpenseUnit")]
        public async Task<IActionResult> CreateExpenseUnitAsync([FromBody] CreateExpenseUnitCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("EditExpenseUnit")]
        public async Task<IActionResult> EditExpenseUnitAsync([FromBody] EditExpenseUnitCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteExpenseUnit")]
        public async Task<IActionResult> DeleteExpenseUnitAsync(Guid id)
        {
            var command = new DeleteExpenseUnitCommand { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
