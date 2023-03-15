using BankingSystem.Data;
using BankingSystem.Data.Entities;
using BankingSystem.DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BankingSystemDbContext _context;

        public UserRepository(BankingSystemDbContext context)
        {
            _context = context;
        }

        public async Task Create(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task Delete(string email)
        {
            var user = await GetUser(email);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUser(string email)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                throw new Exception($"User with {email} doesn't exist");
            }

            return user;

        }
        
    }
}
