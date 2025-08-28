using Application.Commons;
using Application.Persistance.Contracts;
using MediatR;

namespace Application.Feature.Command.Expense.DeleteExpense
{
    public class DeleteExpenseHandler : IRequestHandler<DeleteExpenseCommand, OperationResult>
    {
        private readonly IExpenseRepository _expenseRepository;

        public DeleteExpenseHandler(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<OperationResult> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var expense = await _expenseRepository.GetByIdAsync(request.Id);
                if (expense == null)
                {
                    return new OperationResult().Failed("هزینه مورد نظر یافت نشد");
                }

                await _expenseRepository.DeleteAsync(expense);
                await _expenseRepository.SaveChangesAsync();

                return new OperationResult().Success("هزینه با موفقیت حذف شد");
            }
            catch (Exception ex)
            {
                return new OperationResult().Failed($"خطا در حذف هزینه: {ex.Message}");
            }
        }
    }
}


