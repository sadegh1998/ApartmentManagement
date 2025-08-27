using MediatR;

namespace Application.Feature.Query.Expense.GetAllExpenses
{
    public class GetAllExpensesQuery : IRequest<List<ExpenseViewModel>>
    {
    }
}
