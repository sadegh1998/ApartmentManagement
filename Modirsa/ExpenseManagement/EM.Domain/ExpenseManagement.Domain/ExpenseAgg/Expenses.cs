using _0_Framework.Domain;
using ExpenseManagement.Domain.ExpenseUnitAgg;

namespace ExpenseManagement.Domain.ExpenseAgg
{
    public class Expenses : EntityBase
    {
        public Guid BuildingId { get; private set; }
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime DateIncurred { get; private set; }
        public string AllocationMethod { get;private set; }
        public List<ExpenseUnits> ExpenseUnits { get; private set; }

        public Expenses(Guid buildingId, string description, decimal amount, DateTime dateIncurred, string allocationMethod)
        {
            BuildingId = buildingId;
            Description = description;
            Amount = amount;
            DateIncurred = dateIncurred;
            AllocationMethod = allocationMethod;
        }
        public void Update(Guid buildingId, string description, decimal amount, DateTime dateIncurred, string allocationMethod)
        {
            BuildingId = buildingId;
            Description = description;
            Amount = amount;
            DateIncurred = dateIncurred;
            AllocationMethod = allocationMethod;
        }
    }
    
}
