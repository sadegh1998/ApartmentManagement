using BuildingManagement.Domain.UnitAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Infrastructure.EFCore.Mapping
{
    public class UnitMapping : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.ToTable("Units");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.Property(x => x.OwnerTenanStatus).HasMaxLength(10).IsRequired();
            builder.Property(x => x.NumberOfFamilyMembers).IsRequired();
            builder.Property(x => x.UnitNumber).IsRequired();


            builder.HasOne(x=>x.Building).WithMany(x => x.Units).HasForeignKey(x=> x.BuildingId);
        }
    }
}
