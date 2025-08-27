using Domain.ExpenseAgg;

namespace Application.Persistance.Contracts
{
    public interface IExpenseRepository : IAsyncRepository<Expenses>
    {
        Task<List<Expenses>> SearchAsync(string? description, Guid? buildingId, DateTime? fromDate, DateTime? toDate, decimal? minAmount, decimal? maxAmount);
    }
}
