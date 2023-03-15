using BankingSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Data.Configs
{
    public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CurrentBalance).IsRequired().HasColumnType("money");
            
            builder.Property(p => p.AccountName).IsRequired().HasMaxLength(100);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasIndex(p => p.Id).IsUnique();
        }
    }
}
