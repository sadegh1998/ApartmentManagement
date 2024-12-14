namespace ExpenseManagement.Application.Contract.Expense
{
    public class EditExpense : CreateExpense
    {
        public Guid Id { get; set; }
    }
}
