using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Application.Contract.Expense
{
    public interface IExpenseApplication 
    {
        Task<OperationResult> CreateAsync(CreateExpense command);
        Task<OperationResult> EditAsync(EditExpense command);
        Task<ExpenseViewModel> GetByAsync(Guid id);
        Task<List<ExpenseViewModel>> GetAllAsync();
        Task<List<ExpenseViewModel>> Search(ExpenseSearchModel searchModel);

    }
}
