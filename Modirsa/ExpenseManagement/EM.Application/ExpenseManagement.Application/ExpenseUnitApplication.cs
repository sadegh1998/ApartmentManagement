using _0_Framework.Application;
using ExpenseManagement.Application.Contract.ExpenseUnit;
using ExpenseManagement.Domain.ExpenseUnitAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Application
{
    public class ExpenseUnitApplication : IExpenseUnitApplication
    {
        private readonly IExpenseUnitRepository _expenseUnitRepository;

        public ExpenseUnitApplication(IExpenseUnitRepository expenseUnitRepository)
        {
            _expenseUnitRepository = expenseUnitRepository;
        }

        public async Task<OperationResult> CreateExpenseUnitAsync(CreateExpenseUnit command)
        {
            var operation = new OperationResult();
            if (await _expenseUnitRepository.ExsitsAsync(x => x.ExpenseId == command.ExpenseId && x.UnitId == command.UnitId))
            {
                return operation.Failed(ApplicationMessages.Duplicate);
            }
            var expenseUnit = new ExpenseUnits(command.AmountDue,command.ExpenseId,command.UnitId);
            await _expenseUnitRepository.CreateAsync(expenseUnit);
            await _expenseUnitRepository.SaveChangesAsync();
            return operation.Success();
        }

        public async Task<OperationResult> EditExpenseUnitAsync(UpdateExpenseUnit command)
        {
            var operation = new OperationResult();
            var expenseUnit = await _expenseUnitRepository.GetAsync(command.Id);
            if(expenseUnit == null)
            {
                return operation.Failed(ApplicationMessages.NotFound);
            }
            if (await _expenseUnitRepository.ExsitsAsync(x => x.ExpenseId == command.ExpenseId && x.UnitId == command.UnitId && x.Id != command.Id))
            {
                return operation.Failed(ApplicationMessages.Duplicate);
            }
            expenseUnit.Edit(command.AmountDue, command.ExpenseId, command.UnitId);
            await _expenseUnitRepository.SaveChangesAsync();
            return operation.Success();
        }

        public async Task<List<ExpenseUnitViewModel>> GetAllExpenseUnitAsync()
        {
           var result = await _expenseUnitRepository.GetAllAsync();
            return result.Select(x => new ExpenseUnitViewModel 
            {
                AmountDue = x.AmountDue,
                ExpenseTitle = x.Expenses.Description,
                UnitTitle = ""
            }).ToList();
        }

        public async Task<ExpenseUnitViewModel> GetExpenseUnitByAsync(Guid Id)
        {
            var result = await _expenseUnitRepository.GetAsync(Id);
            return new ExpenseUnitViewModel { AmountDue = result.AmountDue, ExpenseTitle = result.Expenses.Description, UnitTitle = "" };
        }
        public async Task<List<ExpenseUnitViewModel>> Search(ExpenseUnitSearchModel searchModel)
        {
           return await _expenseUnitRepository.Search(searchModel);
        }
    }
}
