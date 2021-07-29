using PynkTalent.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PynkTalent.Interface.Deposit.Strategy
{
    internal interface IDepositStrategy
    {
        bool Deposit(UserModel user, decimal amount);

        decimal DepositAmount(decimal amount);
    }
}