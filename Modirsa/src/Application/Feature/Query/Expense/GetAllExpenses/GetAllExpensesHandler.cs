using Application.Persistance.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Feature.Query.Expense.GetAllExpenses
{
    public class GetAllExpensesHandler : IRequestHandler<GetAllExpensesQuery, List<ExpenseViewModel>>
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;

        public GetAllExpensesHandler(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
        }

        public async Task<List<ExpenseViewModel>> Handle(GetAllExpensesQuery request, CancellationToken cancellationToken)
        {
            var expenses = await _expenseRepository.GetAllAsync();
            return _mapper.Map<List<ExpenseViewModel>>(expenses);
        }
    }
}


