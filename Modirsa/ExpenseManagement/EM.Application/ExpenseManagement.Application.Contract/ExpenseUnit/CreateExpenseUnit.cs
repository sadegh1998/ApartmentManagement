using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Application.Contract.ExpenseUnit
{
    public class CreateExpenseUnit
    {
        public decimal AmountDue { get;  set; }
        public Guid ExpenseId { get;  set; }
        public Guid UnitId { get;  set; }
    }
}
