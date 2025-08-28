using MediatR;

namespace Application.Feature.Query.ExpenseUnit.GetExpenseUnitsByExpenseId
{
    public class GetExpenseUnitsByExpenseIdQuery : IRequest<List<ExpenseUnitViewModel>>
    {
        public Guid ExpenseId { get; }

        public GetExpenseUnitsByExpenseIdQuery(Guid expenseId)
        {
            ExpenseId = expenseId;
        }
    }
}

