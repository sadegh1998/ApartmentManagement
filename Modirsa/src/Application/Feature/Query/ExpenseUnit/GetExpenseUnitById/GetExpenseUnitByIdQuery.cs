using MediatR;

namespace Application.Feature.Query.ExpenseUnit.GetExpenseUnitById
{
    public class GetExpenseUnitByIdQuery : IRequest<ExpenseUnitViewModel>
    {
        public Guid Id { get; }

        public GetExpenseUnitByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}

