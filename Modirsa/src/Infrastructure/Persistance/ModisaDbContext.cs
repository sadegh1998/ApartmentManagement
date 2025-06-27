using Domain.AccountAgg;
using Domain.BuildingAgg;
using Domain.ExpenseAgg;
using Domain.ExpenseUnitAgg;
using Domain.RoleAgg;
using Domain.UnitAgg;
using Infrastructure.DbConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    public class ModisaDbContext : DbContext
    {
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<ExpenseUnits> ExpenseUnits { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected ModisaDbContext(DbContextOptions<ModisaDbContext> options) : base(options)
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
