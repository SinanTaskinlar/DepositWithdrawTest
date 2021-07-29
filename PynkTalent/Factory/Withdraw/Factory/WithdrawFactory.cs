using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PynkTalent.Interface.Deposit.Strategy;
using PynkTalent.Interface.Withdraw.Factory;
using PynkTalent.Interface.Withdraw.Strategy;
using PynkTalent.Models.User;

namespace PynkTalent.Factory.Withdraw.Factory {
	internal class WithdrawFactory : IWithdrawFactory
		{

        private readonly IWithdrawStrategy _withdrawstrategy;

        public WithdrawFactory(IWithdrawStrategy withdrawstrategy)
        {
			_withdrawstrategy = withdrawstrategy;
        }

		public bool Withdraw(UserModel user,decimal amount)
		{
			return _withdrawstrategy.Withdraw(user,amount);
		}

		public decimal WithdrawAmount(decimal balance,decimal amount, string state)
		{
			return _withdrawstrategy.WithdrawAmount(balance,amount, state);
		}
	}
}