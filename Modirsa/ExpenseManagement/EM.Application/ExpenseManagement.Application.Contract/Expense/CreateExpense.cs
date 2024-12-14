using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Application.Contract.Expense
{
    public class CreateExpense
    {
        public Guid BuildingId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateIncurred { get; set; }
        public string AllocationMethod { get; set; }
    }
}
