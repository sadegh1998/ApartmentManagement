using Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DbConfiguration
{
    public class RolePermissionMapping : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.ToTable("RolePermissions", "Acc");

            builder.HasKey(rp => rp.Id);

            builder.HasOne(rp => rp.Role)
       .WithMany(r => r.RolePermissions)
       .HasForeignKey(rp => rp.RoleId);

            builder.HasOne(rp => rp.Permission)
             .WithMany(p => p.RolePermissions)
             .HasForeignKey(rp => rp.PermissionId);

            //builder.Property(rp => rp.RoleId)
            //    .IsRequired();

            //builder.Property(rp => rp.PermissionId)
            //    .IsRequired();

            //builder.HasOne(rp => rp.Role)
            //    .WithMany(r => r.RolePermissions)
            //    .HasForeignKey(rp => rp.RoleId);

            //builder.HasOne(rp => rp.Permission)
            //    .WithMany(p => p.RolePermissions)
            //    .HasForeignKey(rp => rp.PermissionId);
        }
    }
}
