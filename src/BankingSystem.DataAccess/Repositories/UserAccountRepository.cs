using BankingSystem.Data;
using BankingSystem.Data.Entities;
using BankingSystem.DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DataAccess.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly BankingSystemDbContext _context;

        public UserAccountRepository(BankingSystemDbContext context)
        {
            _context = context;
        }
        
        public async Task CreateUserAccount(int userId, string accountName)
        {
            var userAccount = new UserAccount()
            {
                UserId = userId,
                CurrentBalance = 0,
                AccountName = accountName
            };

            await _context.AddAsync(userAccount);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAccount(int userId, int userAccountId)
        {
            var userAccount = await _context.UserAccounts.SingleOrDefaultAsync(x=> x.UserId == userId && x.Id == userAccountId);
            if (userAccount == null)
            {
                throw new Exception($"Account with {userAccountId} doesn't exist");
                return;
            }

            _context.UserAccounts.Remove(userAccount);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserAccount>> GetUsersAccounts(int userId)
        {
            return await _context.UserAccounts.Where(x => x.UserId == userId).ToListAsync();
        }


    }
}
