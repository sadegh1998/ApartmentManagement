using ExpenseManagement.Application;
using ExpenseManagement.Application.Contract.Expense;
using ExpenseManagement.Domain.ExpenseAgg;
using ExpenseManagement.Infrastructure.EfCore;
using ExpenseManagement.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseManagement.Configuration
{
    public class ExpenseBootstrapper
    {
        public void Configuration(IServiceCollection services,string connectionString)
        {
            services.AddTransient<IExpenseRepository, ExpenseRepository>();
            services.AddTransient<IExpenseApplication, ExpenseApplication>();


            services.AddDbContext<ExpenseContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
