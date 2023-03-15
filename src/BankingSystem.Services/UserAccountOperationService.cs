using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Contracts;
using BankingSystem.DataAccess.Contracts;

namespace BankingSystem.Services
{
    public class UserAccountOperationService : IUserAccountOperationService
    {
        private readonly IUserAccountService _accountService;

        public UserAccountOperationService(IUserAccountService accountService)
        {
            _accountService = accountService;
        }

        public void DepositUserAccount(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void WithdrawFromUserAccount(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
