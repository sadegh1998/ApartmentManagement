using Application.Persistance.Contracts;
using Domain.ExpenseUnitAgg;
using Infrastructure.Persistance;

namespace Infrastructure.Repositories
{
    public class ExpenseUnitRepository : RepositoryBase<ExpenseUnits>, IExpenseUnitRepository
    {
        private readonly ModisaDbContext _expenseContext;
        public ExpenseUnitRepository(ModisaDbContext expenseContext) : base(expenseContext) 
        {
            _expenseContext = expenseContext;
        }

        //public async Task<List<ExpenseUnitViewModel>> Search(ExpenseUnitSearchModel searchModel)
        //{
        //    var query = _expenseContext.ExpenseUnits.Include(x => x.Expenses).Select(x=> new ExpenseUnitViewModel
        //    {
        //        AmountDue = x.AmountDue,
        //        ExpenseTitle = x.Expenses.Description,
        //        UnitTitle = ""
        //    });
        //    if(!string.IsNullOrWhiteSpace(searchModel.ExpenseTitle))
        //    {
        //        query = query.Where(x => x.ExpenseTitle.Contains(searchModel.ExpenseTitle));
        //    }
        //    var result = query.ToListAsync();
        //    return await result;
        //}
    }
}
