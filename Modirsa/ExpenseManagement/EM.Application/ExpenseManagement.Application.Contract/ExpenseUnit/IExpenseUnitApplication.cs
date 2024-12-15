using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Application.Contract.ExpenseUnit
{
    public interface IExpenseUnitApplication
    {
        Task<OperationResult> CreateExpenseUnitAsync(CreateExpenseUnit command);
        Task<OperationResult> EditExpenseUnitAsync(UpdateExpenseUnit command);
        Task<ExpenseUnitViewModel> GetExpenseUnitByAsync(Guid Id);
        Task<List<ExpenseUnitViewModel>> GetAllExpenseUnitAsync();
        Task<List<ExpenseUnitViewModel>> Search(ExpenseUnitSearchModel searchModel);


    }
}
