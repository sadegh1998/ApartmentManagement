namespace ModisaApp.Shared.DTO.ExpenseUnit
{
    public class ExpenseUnitViewModel
    {
        public Guid Id { get; set; }
        public decimal AmountDue { get; set; }
        public string ExpenseDescription { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
    }
}


