using MediatR;

namespace Application.Feature.Query.Expense.SearchExpenses
{
    public class SearchExpensesQuery : IRequest<List<ExpenseViewModel>>
    {
        public string? Description { get; set; }
        public Guid? BuildingId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }
    }
}

