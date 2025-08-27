using FluentValidation;

namespace Application.Feature.Command.Expense.EditExpense
{
    public class EditExpenseCommandValidator : AbstractValidator<EditExpenseCommand>
    {
        public EditExpenseCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("شناسه هزینه الزامی است");

            RuleFor(x => x.BuildingId)
                .NotEmpty().WithMessage("شناسه ساختمان الزامی است");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("توضیحات هزینه الزامی است")
                .MaximumLength(500).WithMessage("توضیحات نمی‌تواند بیشتر از 500 کاراکتر باشد");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("مبلغ باید بیشتر از صفر باشد")
                .LessThan(1000000000).WithMessage("مبلغ نمی‌تواند بیشتر از 1 میلیارد باشد");

            RuleFor(x => x.DateIncurred)
                .NotEmpty().WithMessage("تاریخ هزینه الزامی است")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("تاریخ هزینه نمی‌تواند در آینده باشد");

            RuleFor(x => x.AllocationMethod)
                .NotEmpty().WithMessage("روش تخصیص الزامی است")
                .MaximumLength(100).WithMessage("روش تخصیص نمی‌تواند بیشتر از 100 کاراکتر باشد");
        }
    }
}
