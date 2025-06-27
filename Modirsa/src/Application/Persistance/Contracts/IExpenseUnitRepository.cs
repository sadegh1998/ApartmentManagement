using Domain.ExpenseUnitAgg;

namespace Application.Persistance.Contracts
{
    public interface IExpenseUnitRepository : IAsyncRepository<ExpenseUnits>
    {
        //Task<List<ExpenseUnitViewModel>> Search(ExpenseUnitSearchModel searchModel);
    }
}
