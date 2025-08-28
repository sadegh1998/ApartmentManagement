using Application.Commons;
using Application.Persistance.Contracts;
using MediatR;

namespace Application.Feature.Command.ExpenseUnit.DeleteExpenseUnit
{
    public class DeleteExpenseUnitHandler : IRequestHandler<DeleteExpenseUnitCommand, OperationResult>
    {
        private readonly IExpenseUnitRepository _expenseUnitRepository;

        public DeleteExpenseUnitHandler(IExpenseUnitRepository expenseUnitRepository)
        {
            _expenseUnitRepository = expenseUnitRepository;
        }

        public async Task<OperationResult> Handle(DeleteExpenseUnitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var expenseUnit = await _expenseUnitRepository.GetByIdAsync(request.Id);
                if (expenseUnit == null)
                {
                    return new OperationResult().Failed("هزینه واحد مورد نظر یافت نشد");
                }

                await _expenseUnitRepository.DeleteAsync(expenseUnit);
                await _expenseUnitRepository.SaveChangesAsync();

                return new OperationResult().Success("هزینه واحد با موفقیت حذف شد");
            }
            catch (Exception ex)
            {
                return new OperationResult().Failed($"خطا در حذف هزینه واحد: {ex.Message}");
            }
        }
    }
}


