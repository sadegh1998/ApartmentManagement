using Application.Commons;
using Application.Persistance.Contracts;
using Domain.ExpenseAgg;
using MediatR;

namespace Application.Feature.Command.Expense.CreateExpense
{
    public class CreateExpenseHandler : IRequestHandler<CreateExpenseCommand, OperationResult>
    {
        private readonly IExpenseRepository _expenseRepository;

        public CreateExpenseHandler(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<OperationResult> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var expense = new Expenses(
                    request.BuildingId,
                    request.Description,
                    request.Amount,
                    request.DateIncurred,
                    request.AllocationMethod
                );

                await _expenseRepository.CreateAsync(expense);
                await _expenseRepository.SaveChangesAsync();

                return new OperationResult().Success("هزینه با موفقیت ایجاد شد");
            }
            catch (Exception ex)
            {
                return new OperationResult().Failed($"خطا در ایجاد هزینه: {ex.Message}");
            }
        }
    }
}
