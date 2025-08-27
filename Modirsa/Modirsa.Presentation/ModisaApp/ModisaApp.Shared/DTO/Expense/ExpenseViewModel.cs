namespace ModisaApp.Shared.DTO.Expense
{
    public class ExpenseViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime DateIncurred { get; set; }
        public string AllocationMethod { get; set; } = string.Empty;
        public string BuildingName { get; set; } = string.Empty;
        public int ExpenseUnitsCount { get; set; }
    }
}
