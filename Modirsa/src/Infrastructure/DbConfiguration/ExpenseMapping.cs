using Domain.ExpenseAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DbConfiguration
{
    public class ExpenseMapping : IEntityTypeConfiguration<Expenses>
    {
        public void Configure(EntityTypeBuilder<Expenses> builder)
        {
            builder.ToTable("Expenses");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description).IsRequired(false).HasMaxLength(500);
            builder.Property(e=>e.AllocationMethod).IsRequired(false).HasMaxLength(255);
            builder.Property(e => e.Amount).IsRequired();
            builder.Property(e => e.DateIncurred).IsRequired();

            builder.HasMany(e => e.ExpenseUnits).WithOne(e => e.Expenses).HasForeignKey(e => e.ExpenseId);

        }
    }
}
