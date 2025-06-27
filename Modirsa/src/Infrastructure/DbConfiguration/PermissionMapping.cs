using Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DbConfiguration
{
    public class PermissionMapping : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions", "Acc");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Code).HasMaxLength(100).IsRequired().IsUnicode(false);
            builder.HasMany(p => p.RolePermissions)
            .WithOne(rp => rp.Permission)
            .HasForeignKey(rp => rp.PermissionId);
            //builder.Property(p => p.Name)
            //    .IsRequired()
            //    .HasMaxLength(100);

            //builder.HasMany(p => p.RolePermissions)
            //    .WithOne(rp => rp.Permission)
            //    .HasForeignKey(rp => rp.PermissionId);
        }
    }
}
