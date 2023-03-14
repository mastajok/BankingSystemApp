using BankingSystem.Data.Entities;
using BankingSystem.DataAccess.Configurations;

using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DataAccess
{
    public class BankingSystemDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserAccountConfiguration());
        }

        public DbSet<User> Students { get; set; }
        public DbSet<UserAccount> Courses { get; set; }
    }
}
