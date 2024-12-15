using _0_Framework.Infrastructure;
using ExpenseManagement.Application.Contract.Expense;
using ExpenseManagement.Application.Contract.ExpenseUnit;
using ExpenseManagement.Domain.ExpenseUnitAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Infrastructure.EfCore.Repository
{
    public class ExpenseUnitRepository : RepositoryBase<Guid, ExpenseUnits>, IExpenseUnitRepository
    {
        private readonly ExpenseContext _expenseContext;
        public ExpenseUnitRepository(ExpenseContext expenseContext) : base(expenseContext) 
        {
            _expenseContext = expenseContext;
        }

        public async Task<List<ExpenseUnitViewModel>> Search(ExpenseUnitSearchModel searchModel)
        {
            var query = _expenseContext.ExpenseUnits.Include(x => x.Expenses).Select(x=> new ExpenseUnitViewModel
            {
                AmountDue = x.AmountDue,
                ExpenseTitle = x.Expenses.Description,
                UnitTitle = ""
            });
            if(!string.IsNullOrWhiteSpace(searchModel.ExpenseTitle))
            {
                query = query.Where(x => x.ExpenseTitle.Contains(searchModel.ExpenseTitle));
            }
            var result = query.ToListAsync();
            return await result;
        }
    }
}
