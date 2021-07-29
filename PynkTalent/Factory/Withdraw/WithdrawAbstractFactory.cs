using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PynkTalent.Enums.User.State;
using PynkTalent.Factory.Deposit.Factory;
using PynkTalent.Factory.Withdraw.Factory;
using PynkTalent.Factory.Withdraw.Strategy;
using PynkTalent.Interface.Deposit.Factory;
using PynkTalent.Interface.Withdraw.Factory;

namespace PynkTalent.Factory.Withdraw
{
	internal class WithdrawAbstractFactory
	{
        public IWithdrawFactory Get(Country user_country)
        {
            IWithdrawFactory deposit_factory;

            switch ( user_country )
            {
                case Country.All:
                    deposit_factory = new WithdrawFactory(new BaseStrategy());
                    break;

                case Country.UnitedKingdom:
                    deposit_factory = new WithdrawFactory(new UKStrategy());
                    break;

                case Country.UnitedStates:
                    deposit_factory = new WithdrawFactory(new USStrategy());
                    break;

                case Country.Germany:
                    deposit_factory = new WithdrawFactory(new DEStrategy());
                    break;

                default:

                    deposit_factory = null;

                    break;
            }

            return deposit_factory;
        }
    }
}