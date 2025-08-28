using Application.Commons;
using Application.Persistance.Contracts;
using MediatR;

namespace Application.Feature.Command.Expense.EditExpense
{
    public class EditExpenseHandler : IRequestHandler<EditExpenseCommand, OperationResult>
    {
        private readonly IExpenseRepository _expenseRepository;

        public EditExpenseHandler(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<OperationResult> Handle(EditExpenseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var expense = await _expenseRepository.GetByIdAsync(request.Id);
                if (expense == null)
                {
                    return new OperationResult().Failed("هزینه مورد نظر یافت نشد");
                }

                expense.Update(
                    request.BuildingId,
                    request.Description,
                    request.Amount,
                    request.DateIncurred,
                    request.AllocationMethod
                );

                await _expenseRepository.SaveChangesAsync();

                return new OperationResult().Success("هزینه با موفقیت ویرایش شد");
            }
            catch (Exception ex)
            {
                return new OperationResult().Failed($"خطا در ویرایش هزینه: {ex.Message}");
            }
        }
    }
}


