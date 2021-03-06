using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PynkTalent.Interface.Withdraw.Strategy;
using PynkTalent.Models.User;

namespace PynkTalent.Factory.Withdraw.Strategy
{
	public class BaseStrategy : IWithdrawStrategy
	{
		private decimal _least_amount = 20;

		public decimal Least_amount
		{
			get {
				return _least_amount;
			}
			set {
				_least_amount = value;
			}
		}


		public bool Withdraw(UserModel user,decimal amount)
		{
			if (amount <= Least_amount || user.Country_state == Enums.User.State.Country.Germany)
			{
				return false;
			}

			user.Balance = WithdrawAmount(user.Balance, amount, user.Country);

			return true;
		}

		public decimal WithdrawAmount(decimal balance, decimal amount, string state)
		{

			if ( state == "DE" )
				return 0;
			if ( amount < Least_amount )
				return 0;
			if ( amount > balance )
				return 0;

			return balance -= amount;
		}
	}
}