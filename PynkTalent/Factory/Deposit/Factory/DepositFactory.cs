using PynkTalent.Interface.Deposit.Factory;
using PynkTalent.Interface.Deposit.Strategy;
using PynkTalent.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PynkTalent.Factory.Deposit.Factory
{
    internal class DepositFactory : IDepositFactory
    {
        private readonly IDepositStrategy _deposit_strategy;

        public DepositFactory(IDepositStrategy depositStrategy)
        {
            _deposit_strategy = depositStrategy;
        }

        public bool Deposit(UserModel user, decimal amount)
        {
            return _deposit_strategy.Deposit(user, amount);
        }

        public decimal DepositAmount(decimal amount)
        {
            return _deposit_strategy.DepositAmount(amount);
        }
    }
}