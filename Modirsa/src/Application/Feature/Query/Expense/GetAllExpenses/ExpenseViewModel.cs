namespace Application.Feature.Query.Expense.GetAllExpenses
{
    public class ExpenseViewModel
    {
        public Guid Id { get; set; }
        public Guid BuildingId { get; set; }
        public string BuildingName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime DateIncurred { get; set; }
        public string AllocationMethod { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public int ExpenseUnitsCount { get; set; }
    }
}


