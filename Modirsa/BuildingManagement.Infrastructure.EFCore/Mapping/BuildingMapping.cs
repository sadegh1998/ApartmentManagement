using BuildingManagement.Domain.BuildingAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingManagement.Infrastructure.EFCore.Mapping
{
    public class BuildingMapping : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.ToTable("Buildings");
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(500).IsRequired();
            builder.Property(x => x.BuildingUnitsNo).IsRequired();
            builder.Property(x => x.Floors).IsRequired();
            builder.Property(x => x.Image).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Image).HasMaxLength(500).IsRequired(false);

        }
    }
}
