using Application.Persistance.Contracts;
using Domain.ExpenseUnitAgg;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ExpenseUnitRepository : RepositoryBase<ExpenseUnits>, IExpenseUnitRepository
    {
        private readonly ModisaDbContext _expenseContext;
        
        public ExpenseUnitRepository(ModisaDbContext expenseContext) : base(expenseContext)
        {
            _expenseContext = expenseContext;
        }

        public async Task<List<ExpenseUnits>> GetByExpenseIdAsync(Guid expenseId)
        {
            return await _expenseContext.ExpenseUnits
                .Include(x => x.Expenses)
                .Include(x => x.Unit)
                .Where(x => x.ExpenseId == expenseId)
                .ToListAsync();
        }
    }
}
