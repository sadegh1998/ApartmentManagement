using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username).HasMaxLength(100);
            builder.Property(x => x.FullName).HasMaxLength(100);
            builder.Property(x => x.Password).HasMaxLength(1000);
            builder.Property(x => x.ProfilePicture).HasMaxLength(500);
            builder.Property(x => x.Mobile).HasMaxLength(20);
            builder.Property(x => x.LastSendSms).HasMaxLength(10).IsRequired(false);
            builder.Property(x => x.Email).HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.Token).HasMaxLength(256).IsRequired(false);



            builder.HasOne(x => x.Role).WithMany(x => x.Accounts).HasForeignKey(x => x.RoleId);


        }
    }
}
