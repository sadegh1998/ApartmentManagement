using Domain;
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
      
        public ModisaDbContext()
        {
            
        }
        public ModisaDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<ExpenseUnits> ExpenseUnits { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ExpenseMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreationDate = DateTime.Now;
                        break;

                    //case EntityState.Modified:
                    //    entry.Entity.UpdatedAt = DateTime.Now;
                    //    break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
