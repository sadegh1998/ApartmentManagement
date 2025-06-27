using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.AccountAgg;

namespace Infrastructure.DbConfiguration
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

        }
    }
}
