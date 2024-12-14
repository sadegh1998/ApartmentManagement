using _0_Framework.Domain;

namespace ExpenseManagement.Domain.ExpenseAgg
{
    public interface IExpenseRepository : IRepository<Guid,Expenses>
    {
    }
}
