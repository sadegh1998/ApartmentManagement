using Application.Persistance.Contracts;
using Domain.ExpenseAgg;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ExpenseRepository : RepositoryBase<Expenses>, IExpenseRepository
    {
        private readonly ModisaDbContext _expenseContext;
        
        public ExpenseRepository(ModisaDbContext expenseContext) : base(expenseContext)
        {
            _expenseContext = expenseContext;
        }

        public async Task<List<Expenses>> SearchAsync(string? description, Guid? buildingId, DateTime? fromDate, DateTime? toDate, decimal? minAmount, decimal? maxAmount)
        {
            var query = _expenseContext.Expenses
                .Include(x => x.Building)
                .Include(x => x.ExpenseUnits)
                .AsQueryable();

            if (!string.IsNullOrEmpty(description))
            {
                query = query.Where(x => x.Description.Contains(description));
            }

            if (buildingId.HasValue)
            {
                query = query.Where(x => x.BuildingId == buildingId.Value);
            }

            if (fromDate.HasValue)
            {
                query = query.Where(x => x.DateIncurred >= fromDate.Value);
            }

            if (toDate.HasValue)
            {
                query = query.Where(x => x.DateIncurred <= toDate.Value);
            }

            if (minAmount.HasValue)
            {
                query = query.Where(x => x.Amount >= minAmount.Value);
            }

            if (maxAmount.HasValue)
            {
                query = query.Where(x => x.Amount <= maxAmount.Value);
            }

            return await query.ToListAsync();
        }
    }
}
