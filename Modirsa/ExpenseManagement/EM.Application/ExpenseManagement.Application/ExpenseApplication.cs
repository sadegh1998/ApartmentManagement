using _0_Framework.Application;
using ExpenseManagement.Application.Contract.Expense;
using ExpenseManagement.Domain.ExpenseAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Application
{
    public class ExpenseApplication : IExpenseApplication
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseApplication(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<OperationResult> CreateAsync(CreateExpense command)
        {
            var operation = new OperationResult();
            if(await _expenseRepository.ExsitsAsync(x=>x.BuildingId == command.BuildingId && x.Description == command.Description))
            {
                return operation.Failed(ApplicationMessages.Duplicate);
            }
            var expense = new Expenses(command.BuildingId, command.Description,command.Amount, command.DateIncurred, command.AllocationMethod);
            await _expenseRepository.CreateAsync(expense);
            await _expenseRepository.SaveChangesAsync();
            return operation.Success();
        }

        public async Task<OperationResult> EditAsync(EditExpense command)
        {
            var operation = new OperationResult();
            var expense = await _expenseRepository.GetAsync(command.Id);
            if(expense == null)
            {
                return operation.Failed(ApplicationMessages.NotFound);
            }
            if (await _expenseRepository.ExsitsAsync(x => x.BuildingId == command.BuildingId && x.Description == command.Description && x.Id != command.Id))
            {
                return operation.Failed(ApplicationMessages.Duplicate);
            }
            expense.Update(command.BuildingId, command.Description, command.Amount, command.DateIncurred, command.AllocationMethod);
            await _expenseRepository.SaveChangesAsync();
            return operation.Success();
        }

        public async Task<List<ExpenseViewModel>> GetAllAsync()
        {
            var result = await _expenseRepository.GetAllAsync();
            return result.Select(x => new ExpenseViewModel
            {
                AllocationMethod = x.AllocationMethod,
                Amount = x.Amount,
                BuildingName = "",
                DateIncurred = x.DateIncurred,
                Description = x.Description
            }).ToList();
        }

        public async Task<ExpenseViewModel> GetByAsync(Guid id)
        {
           var result = await _expenseRepository.GetAsync(id);
            return new ExpenseViewModel 
            { 
            AllocationMethod = result.AllocationMethod, 
                Amount = result.Amount,
                BuildingName = "",
                DateIncurred = result.DateIncurred,
                Description = result.Description
            };
        }
        //TODO : This method must be fixed after create ACL between Expense and Building
        public async Task<List<ExpenseViewModel>> Search(ExpenseSearchModel searchModel)
        {
            var result =await _expenseRepository.GetAllAsync();
            if(string.IsNullOrWhiteSpace(searchModel.BuildingName))
            {
                result = result.Where(x => x.BuildingId == Guid.NewGuid()).ToList();
            }
            return result.Select(x=>new ExpenseViewModel
            {
                AllocationMethod = x.AllocationMethod,
                Amount= x.Amount,   
                BuildingName= "", 
                DateIncurred= x.DateIncurred,
                Description = x.Description
            }).ToList();
        }
    }
}
