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

            // Configure relationships
            modelBuilder.Entity<Expenses>()
                .HasOne(e => e.Building)
                .WithMany()
                .HasForeignKey(e => e.BuildingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExpenseUnits>()
                .HasOne(eu => eu.Expenses)
                .WithMany(e => e.ExpenseUnits)
                .HasForeignKey(eu => eu.ExpenseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ExpenseUnits>()
                .HasOne(eu => eu.Unit)
                .WithMany()
                .HasForeignKey(eu => eu.UnitId)
                .OnDelete(DeleteBehavior.Restrict);

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
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
