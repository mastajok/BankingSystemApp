using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Contracts
{
    public interface IUserAccountOperationService
    {
        void DepositUserAccount(decimal amount);

        void WithdrawFromUserAccount(decimal amount);
    }
}
