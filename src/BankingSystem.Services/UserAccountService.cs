using BankingSystem.Contracts;
using BankingSystem.DataAccess.Contracts;

namespace BankingSystem.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public UserAccountService(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public void CreateUserAccount()
        {
            throw new NotImplementedException();
        }

        public void DeleteUserAccount()
        {
            throw new NotImplementedException();
        }

        public void GetUserAccounts(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
