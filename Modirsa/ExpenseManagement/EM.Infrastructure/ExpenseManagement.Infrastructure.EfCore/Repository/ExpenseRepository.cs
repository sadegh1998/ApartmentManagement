using _0_Framework.Infrastructure;
using ExpenseManagement.Domain.ExpenseAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Infrastructure.EfCore.Repository
{
    public class ExpenseRepository : RepositoryBase<Guid,Expenses> , IExpenseRepository
    {
        private readonly ExpenseContext _expenseContext;
        public ExpenseRepository(ExpenseContext expenseContext) : base(expenseContext) 
        {
            _expenseContext = expenseContext;   
        }
    }
}
