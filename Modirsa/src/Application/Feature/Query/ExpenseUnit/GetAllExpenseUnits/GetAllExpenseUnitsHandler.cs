using Application.Persistance.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Feature.Query.ExpenseUnit.GetAllExpenseUnits
{
    public class GetAllExpenseUnitsHandler : IRequestHandler<GetAllExpenseUnitsQuery, List<ExpenseUnitViewModel>>
    {
        private readonly IExpenseUnitRepository _expenseUnitRepository;
        private readonly IMapper _mapper;

        public GetAllExpenseUnitsHandler(IExpenseUnitRepository expenseUnitRepository, IMapper mapper)
        {
            _expenseUnitRepository = expenseUnitRepository;
            _mapper = mapper;
        }

        public async Task<List<ExpenseUnitViewModel>> Handle(GetAllExpenseUnitsQuery request, CancellationToken cancellationToken)
        {
            var expenseUnits = await _expenseUnitRepository.GetAllAsync();
            return _mapper.Map<List<ExpenseUnitViewModel>>(expenseUnits);
        }
    }
}
