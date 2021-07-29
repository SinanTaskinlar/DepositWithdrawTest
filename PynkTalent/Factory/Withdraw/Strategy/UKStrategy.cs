using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PynkTalent.Factory.Withdraw.Strategy
{
	public class UKStrategy : BaseStrategy
	{
		public UKStrategy()
		{
			Least_amount = 10;
		}
	}
}