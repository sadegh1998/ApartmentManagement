using ExpenseManagement.Domain.ExpenseAgg;
using ExpenseManagement.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Infrastructure.EfCore
{
    public class ExpenseContext : DbContext
    {
        public DbSet<Expenses> Expenses { get; set; }
        public ExpenseContext(DbContextOptions<ExpenseContext> options) : base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ExpenseMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
