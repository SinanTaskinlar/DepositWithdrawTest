using PynkTalent.Enums.User.State;
using PynkTalent.Factory.Deposit.Factory;
using PynkTalent.Factory.Deposit.Strategy;
using PynkTalent.Interface.Deposit.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PynkTalent.Factory.Deposit
{
    internal class DepositAbstractFactory
    {
        public IDepositFactory Get(Country user_country)
        {
            IDepositFactory deposit_factory;

            switch (user_country)
            {
                case Country.All:
                    deposit_factory = new DepositFactory(new BaseStrategy());
                    break;

                case Country.UnitedKingdom:
                    deposit_factory = new DepositFactory(new UKStrategy());
                    break;

                case Country.UnitedStates:
                    deposit_factory = new DepositFactory(new USStrategy());
                    break;

                case Country.Germany:
                    deposit_factory = new DepositFactory(new DEStrategy());
                    break;

                default:

                    deposit_factory = null;

                    break;
            }

            return deposit_factory;
        }
    }
}