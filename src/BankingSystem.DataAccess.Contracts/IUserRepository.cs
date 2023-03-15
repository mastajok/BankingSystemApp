using BankingSystem.Data.Entities;

namespace BankingSystem.DataAccess.Contracts
{
    public interface IUserRepository
    {
        Task Create(User user);

        Task Delete(string email);

        Task<User> GetUser(string email);

        Task<IList<User>> GetAll();
    }
}
