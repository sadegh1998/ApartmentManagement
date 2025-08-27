using Application.Commons;
using MediatR;

namespace Application.Feature.Command.ExpenseUnit.CreateExpenseUnit
{
    public class CreateExpenseUnitCommand : IRequest<OperationResult>
    {
        public required decimal AmountDue { get; set; }
        public required Guid ExpenseId { get; set; }
        public required Guid UnitId { get; set; }
    }
}
