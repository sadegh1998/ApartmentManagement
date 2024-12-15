using _0_Framework.Domain;
using ExpenseManagement.Application.Contract.Expense;
using ExpenseManagement.Application.Contract.ExpenseUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Domain.ExpenseUnitAgg
{
    public interface IExpenseUnitRepository : IRepository<Guid,ExpenseUnits>
    {
        Task<List<ExpenseUnitViewModel>> Search(ExpenseUnitSearchModel searchModel);
    }
}
