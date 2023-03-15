using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Dtos
{
    public class BaseUserAccountOperationDto
    {
        public int UserId { get; set; }

        public int? UserAccountId { get; set; }

    }
}
