using PynkTalent.Interface.Deposit.Strategy;
using PynkTalent.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PynkTalent.Factory.Deposit.Strategy
{
    public class BaseStrategy : IDepositStrategy
    {
        #region Field

        private decimal _fee = 6;

        #endregion Field

        public decimal fee
        {
            get
            {
                return _fee;
            }
            set
            {
                _fee = value;
            }
        }

        public virtual bool Deposit(UserModel user, decimal amount)
        {
            if (amount <= fee)
            {
                return false;
            }

            var new_amount = DepositAmount(amount);

            user.balance += new_amount;

            return true;
        }

        public virtual decimal DepositAmount(decimal amount)
        {
            if (amount <= fee)
            {
                return -1;
            }

            return amount - fee;
        }
    }
}