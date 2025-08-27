using Application.Commons;
using MediatR;

namespace Application.Feature.Command.Expense.DeleteExpense
{
    public class DeleteExpenseCommand : IRequest<OperationResult>
    {
        public required Guid Id { get; set; }
    }
}
