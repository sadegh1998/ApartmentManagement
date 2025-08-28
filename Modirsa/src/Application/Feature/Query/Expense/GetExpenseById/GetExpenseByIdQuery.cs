using MediatR;

namespace Application.Feature.Query.Expense.GetExpenseById
{
    public class GetExpenseByIdQuery : IRequest<ExpenseViewModel>
    {
        public Guid Id { get; }

        public GetExpenseByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}

