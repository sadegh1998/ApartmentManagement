using Domain.ExpenseAgg;

namespace Application.Persistance.Contracts
{
    public interface IExpenseRepository : IAsyncRepository<Expenses>
    {
    }
}
