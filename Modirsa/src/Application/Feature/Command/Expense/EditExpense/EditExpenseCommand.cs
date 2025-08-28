using Application.Commons;
using MediatR;

namespace Application.Feature.Command.Expense.EditExpense
{
    public class EditExpenseCommand : IRequest<OperationResult>
    {
        public required Guid Id { get; set; }
        public required Guid BuildingId { get; set; }
        public required string Description { get; set; }
        public required decimal Amount { get; set; }
        public required DateTime DateIncurred { get; set; }
        public required string AllocationMethod { get; set; }
    }
}


