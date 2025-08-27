using Application.Persistance.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Feature.Query.ExpenseUnit.GetExpenseUnitById
{
    public class GetExpenseUnitByIdHandler : IRequestHandler<GetExpenseUnitByIdQuery, ExpenseUnitViewModel>
    {
        private readonly IExpenseUnitRepository _expenseUnitRepository;
        private readonly IMapper _mapper;

        public GetExpenseUnitByIdHandler(IExpenseUnitRepository expenseUnitRepository, IMapper mapper)
        {
            _expenseUnitRepository = expenseUnitRepository;
            _mapper = mapper;
        }

        public async Task<ExpenseUnitViewModel> Handle(GetExpenseUnitByIdQuery request, CancellationToken cancellationToken)
        {
            var expenseUnit = await _expenseUnitRepository.GetByIdAsync(request.Id);
            return _mapper.Map<ExpenseUnitViewModel>(expenseUnit);
        }
    }
}
