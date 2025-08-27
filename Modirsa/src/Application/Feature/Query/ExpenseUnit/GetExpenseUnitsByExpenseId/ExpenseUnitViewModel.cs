namespace Application.Feature.Query.ExpenseUnit.GetExpenseUnitsByExpenseId
{
    public class ExpenseUnitViewModel
    {
        public Guid Id { get; set; }
        public decimal AmountDue { get; set; }
        public Guid ExpenseId { get; set; }
        public string ExpenseDescription { get; set; } = string.Empty;
        public Guid UnitId { get; set; }
        public string UnitName { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
    }
}
