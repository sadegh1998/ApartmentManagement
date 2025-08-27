using Application.Commons;
using MediatR;

namespace Application.Feature.Command.ExpenseUnit.EditExpenseUnit
{
    public class EditExpenseUnitCommand : IRequest<OperationResult>
    {
        public required Guid Id { get; set; }
        public required decimal AmountDue { get; set; }
        public required Guid ExpenseId { get; set; }
        public required Guid UnitId { get; set; }
    }
}
