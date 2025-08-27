using Application.Feature.Command.Expense.CreateExpense;
using Application.Feature.Command.Expense.EditExpense;
using Application.Feature.Command.Expense.DeleteExpense;
using Application.Feature.Query.Expense.GetAllExpenses;
using Application.Feature.Query.Expense.GetExpenseById;
using Application.Feature.Query.Expense.SearchExpenses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ModisaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpenseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllExpenses")]
        public async Task<IActionResult> GetAllExpensesAsync()
        {
            var query = new GetAllExpensesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetExpenseById")]
        public async Task<IActionResult> GetExpenseByIdAsync(Guid id)
        {
            var query = new GetExpenseByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("SearchExpenses")]
        public async Task<IActionResult> SearchExpensesAsync([FromQuery] SearchExpensesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateExpense")]
        public async Task<IActionResult> CreateExpenseAsync([FromBody] CreateExpenseCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("EditExpense")]
        public async Task<IActionResult> EditExpenseAsync([FromBody] EditExpenseCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteExpense")]
        public async Task<IActionResult> DeleteExpenseAsync(Guid id)
        {
            var command = new DeleteExpenseCommand { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
