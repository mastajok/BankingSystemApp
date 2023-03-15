using BankingSystem.Data.Entities;

namespace BankingSystem.DataAccess.Contracts
{
    public interface IUserAccountRepository
    {
        Task CreateUserAccount(int userId, string accountName);

        Task DeleteUserAccount(int userId, int userAccountId);

        Task<IEnumerable<UserAccount>> GetUsersAccounts(int userId);
    }
}
