using Application.Persistance.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Feature.Query.ExpenseUnit.GetExpenseUnitsByExpenseId
{
    public class GetExpenseUnitsByExpenseIdHandler : IRequestHandler<GetExpenseUnitsByExpenseIdQuery, List<ExpenseUnitViewModel>>
    {
        private readonly IExpenseUnitRepository _expenseUnitRepository;
        private readonly IMapper _mapper;

        public GetExpenseUnitsByExpenseIdHandler(IExpenseUnitRepository expenseUnitRepository, IMapper mapper)
        {
            _expenseUnitRepository = expenseUnitRepository;
            _mapper = mapper;
        }

        public async Task<List<ExpenseUnitViewModel>> Handle(GetExpenseUnitsByExpenseIdQuery request, CancellationToken cancellationToken)
        {
            var expenseUnits = await _expenseUnitRepository.GetByExpenseIdAsync(request.ExpenseId);
            return _mapper.Map<List<ExpenseUnitViewModel>>(expenseUnits);
        }
    }
}


