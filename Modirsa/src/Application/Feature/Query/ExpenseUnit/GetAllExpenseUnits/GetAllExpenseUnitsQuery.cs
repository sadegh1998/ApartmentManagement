using MediatR;

namespace Application.Feature.Query.ExpenseUnit.GetAllExpenseUnits
{
    public class GetAllExpenseUnitsQuery : IRequest<List<ExpenseUnitViewModel>>
    {
    }
}
