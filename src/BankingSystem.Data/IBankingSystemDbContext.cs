using BankingSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Data
{
    public interface IBankingSystemDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}
