using ExpenseManagement.Domain.ExpenseUnitAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Infrastructure.EfCore.Mapping
{
    public class ExpenseUnitMapping : IEntityTypeConfiguration<ExpenseUnits>
    {
        public void Configure(EntityTypeBuilder<ExpenseUnits> builder)
        {
            builder.ToTable("ExpenseUnits");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.AmountDue).IsRequired();
            builder.HasOne(x => x.Expenses).WithMany(x => x.ExpenseUnits).HasForeignKey(x => x.ExpenseId);
        }
    }
}
