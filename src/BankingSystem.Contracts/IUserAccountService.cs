using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Contracts
{
    public interface IUserAccountService
    {
        void CreateUserAccount();

        void DeleteUserAccount();

        void GetUserAccounts(int userId);
    }
}
