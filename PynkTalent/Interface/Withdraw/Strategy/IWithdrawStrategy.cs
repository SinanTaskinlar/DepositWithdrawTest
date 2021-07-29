using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PynkTalent.Models.User;

namespace PynkTalent.Interface.Withdraw.Strategy {
	internal interface IWithdrawStrategy {
		bool Withdraw(UserModel user,decimal amount);

		decimal WithdrawAmount(decimal balance,decimal amount, string state);
	}
}
