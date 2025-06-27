using Domain.ExpenseAgg;

namespace Domain.ExpenseUnitAgg
{
    public class ExpenseUnits : EntityBase
    {
      
        public decimal AmountDue { get;private set; }
        public Guid ExpenseId { get; private set; }
        public Expenses Expenses { get; private set; }
        public Guid UnitId { get; private set; }

        public ExpenseUnits(decimal amountDue, Guid expenseId, Guid unitId)
        {
            AmountDue = amountDue;
            ExpenseId = expenseId;
            UnitId = unitId;
        }
        public void  Edit(decimal amountDue, Guid expenseId, Guid unitId)
        {
            AmountDue = amountDue;
            ExpenseId = expenseId;
            UnitId = unitId;
        }
    }
}
