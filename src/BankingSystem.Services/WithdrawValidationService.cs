using BankingSystem.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Services
{
    public class WithdrawValidationService : IWithdrawValidationService
    {
        private readonly IUserAccountService _accountService;

        public WithdrawValidationService(IUserAccountService accountService)
        {
            _accountService = accountService;
        }
    }
}
