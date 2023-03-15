using BankingSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Data.Configs
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(50);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasIndex(p => new { p.FirstName, p.LastName, p.Email }).IsUnique();

            builder.HasMany(p => p.Accounts).WithOne().HasForeignKey(p => p.UserId).IsRequired(false);
        }
    }
}
