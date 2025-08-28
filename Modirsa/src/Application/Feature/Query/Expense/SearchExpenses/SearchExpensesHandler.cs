using Application.Persistance.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Feature.Query.Expense.SearchExpenses
{
    public class SearchExpensesHandler : IRequestHandler<SearchExpensesQuery, List<ExpenseViewModel>>
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;

        public SearchExpensesHandler(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
        }

        public async Task<List<ExpenseViewModel>> Handle(SearchExpensesQuery request, CancellationToken cancellationToken)
        {
            var expenses = await _expenseRepository.SearchAsync(
                request.Description,
                request.BuildingId,
                request.FromDate,
                request.ToDate,
                request.MinAmount,
                request.MaxAmount
            );
            
            return _mapper.Map<List<ExpenseViewModel>>(expenses);
        }
    }
}


