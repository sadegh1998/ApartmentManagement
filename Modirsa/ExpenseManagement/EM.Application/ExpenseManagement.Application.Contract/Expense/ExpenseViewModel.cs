namespace ExpenseManagement.Application.Contract.Expense
{
    public class ExpenseViewModel
    {
        public string BuildingName { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateIncurred { get; set; }
        public string AllocationMethod { get; set; }
    }
}
