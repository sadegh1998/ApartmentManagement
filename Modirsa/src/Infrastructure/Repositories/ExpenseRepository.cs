using Application.Persistance.Contracts;
using Domain.ExpenseAgg;
using Infrastructure.Persistance;

namespace Infrastructure.Repositories
{
    public class ExpenseRepository : RepositoryBase<Expenses> , IExpenseRepository
    {
        private readonly ModisaDbContext _expenseContext;
        public ExpenseRepository(ModisaDbContext expenseContext) : base(expenseContext) 
        {
            _expenseContext = expenseContext;   
        }
    }
}
