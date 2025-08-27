using Domain.ExpenseUnitAgg;

namespace Application.Persistance.Contracts
{
    public interface IExpenseUnitRepository : IAsyncRepository<ExpenseUnits>
    {
        Task<List<ExpenseUnits>> GetByExpenseIdAsync(Guid expenseId);
    }
}
