using Application.Commons;
using Application.Persistance.Contracts;
using MediatR;

namespace Application.Feature.Command.ExpenseUnit.EditExpenseUnit
{
    public class EditExpenseUnitHandler : IRequestHandler<EditExpenseUnitCommand, OperationResult>
    {
        private readonly IExpenseUnitRepository _expenseUnitRepository;

        public EditExpenseUnitHandler(IExpenseUnitRepository expenseUnitRepository)
        {
            _expenseUnitRepository = expenseUnitRepository;
        }

        public async Task<OperationResult> Handle(EditExpenseUnitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var expenseUnit = await _expenseUnitRepository.GetByIdAsync(request.Id);
                if (expenseUnit == null)
                {
                    return new OperationResult().Failed("هزینه واحد مورد نظر یافت نشد");
                }

                expenseUnit.Edit(
                    request.AmountDue,
                    request.ExpenseId,
                    request.UnitId
                );

                await _expenseUnitRepository.SaveChangesAsync();

                return new OperationResult().Success("هزینه واحد با موفقیت ویرایش شد");
            }
            catch (Exception ex)
            {
                return new OperationResult().Failed($"خطا در ویرایش هزینه واحد: {ex.Message}");
            }
        }
    }
}
