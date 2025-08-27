namespace ModisaApp.Shared.DTO.ExpenseUnit
{
    public class CreateExpenseUnit
    {
        public decimal AmountDue { get; set; }
        public Guid ExpenseId { get; set; }
        public Guid UnitId { get; set; }
    }
}
