using FluentValidation;

namespace Application.Feature.Command.ExpenseUnit.EditExpenseUnit
{
    public class EditExpenseUnitCommandValidator : AbstractValidator<EditExpenseUnitCommand>
    {
        public EditExpenseUnitCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("شناسه هزینه واحد الزامی است");

            RuleFor(x => x.AmountDue)
                .GreaterThan(0).WithMessage("مبلغ قابل پرداخت باید بیشتر از صفر باشد")
                .LessThan(1000000000).WithMessage("مبلغ قابل پرداخت نمی‌تواند بیشتر از 1 میلیارد باشد");

            RuleFor(x => x.ExpenseId)
                .NotEmpty().WithMessage("شناسه هزینه الزامی است");

            RuleFor(x => x.UnitId)
                .NotEmpty().WithMessage("شناسه واحد الزامی است");
        }
    }
}


