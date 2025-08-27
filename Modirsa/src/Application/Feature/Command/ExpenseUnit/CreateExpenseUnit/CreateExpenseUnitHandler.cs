using Application.Commons;
using Application.Persistance.Contracts;
using Domain.ExpenseUnitAgg;
using MediatR;

namespace Application.Feature.Command.ExpenseUnit.CreateExpenseUnit
{
    public class CreateExpenseUnitHandler : IRequestHandler<CreateExpenseUnitCommand, OperationResult>
    {
        private readonly IExpenseUnitRepository _expenseUnitRepository;

        public CreateExpenseUnitHandler(IExpenseUnitRepository expenseUnitRepository)
        {
            _expenseUnitRepository = expenseUnitRepository;
        }

        public async Task<OperationResult> Handle(CreateExpenseUnitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var expenseUnit = new ExpenseUnits(
                    request.AmountDue,
                    request.ExpenseId,
                    request.UnitId
                );

                await _expenseUnitRepository.CreateAsync(expenseUnit);
                await _expenseUnitRepository.SaveChangesAsync();

                return new OperationResult().Success("هزینه واحد با موفقیت ایجاد شد");
            }
            catch (Exception ex)
            {
                return new OperationResult().Failed($"خطا در ایجاد هزینه واحد: {ex.Message}");
            }
        }
    }
}
