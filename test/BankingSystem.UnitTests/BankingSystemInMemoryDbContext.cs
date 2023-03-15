using BankingSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.UnitTests
{
    public class BankingSystemInMemoryDbContext : BankingSystemDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("BankingSystemDb");
        }
    }
}
