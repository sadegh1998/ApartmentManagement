using Domain.ExpenseUnitAgg;
using Domain.BuildingAgg;

namespace Domain.ExpenseAgg
{
    public class Expenses : EntityBase
    {
        public Guid BuildingId { get; private set; }
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime DateIncurred { get; private set; }
        public string AllocationMethod { get; private set; }
        public List<ExpenseUnits> ExpenseUnits { get; private set; }
        public Building Building { get; private set; }

        public Expenses(Guid buildingId, string description, decimal amount, DateTime dateIncurred, string allocationMethod)
        {
            BuildingId = buildingId;
            Description = description;
            Amount = amount;
            DateIncurred = dateIncurred;
            AllocationMethod = allocationMethod;
            ExpenseUnits = new List<ExpenseUnits>();
        }

        public void Update(Guid buildingId, string description, decimal amount, DateTime dateIncurred, string allocationMethod)
        {
            BuildingId = buildingId;
            Description = description;
            Amount = amount;
            DateIncurred = dateIncurred;
            AllocationMethod = allocationMethod;
        }

        public void AddExpenseUnit(ExpenseUnits expenseUnit)
        {
            if (expenseUnit != null)
            {
                ExpenseUnits.Add(expenseUnit);
            }
        }

        public void RemoveExpenseUnit(Guid expenseUnitId)
        {
            var expenseUnit = ExpenseUnits.FirstOrDefault(x => x.Id == expenseUnitId);
            if (expenseUnit != null)
            {
                ExpenseUnits.Remove(expenseUnit);
            }
        }
    }
}
