using Application.Commons;
using MediatR;

namespace Application.Feature.Command.ExpenseUnit.DeleteExpenseUnit
{
    public class DeleteExpenseUnitCommand : IRequest<OperationResult>
    {
        public required Guid Id { get; set; }
    }
}
