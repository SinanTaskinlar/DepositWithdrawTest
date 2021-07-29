using PynkTalent.Factory.Deposit;
using PynkTalent.Factory.Withdraw;
using PynkTalent.Interface.Deposit.Factory;
using PynkTalent.Interface.Withdraw.Factory;
using PynkTalent.Models.State;
using PynkTalent.Models.User.Country.State;

namespace PynkTalent.Models.User
{
    public class UserModel
    {
		#region Field

		private BaseState _country_state;
        private IDepositFactory deposit_factory;
        private IWithdrawFactory withdraw_factory;

        #endregion Field

        #region Properties

        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Country { get; set; }
        public decimal Balance { get; set; }

        #endregion Properties

        #region Factory

        private void SetFactory()
        {
            var deposit_abstract_factory = new DepositAbstractFactory();
            var withdraw_abstract_factory = new WithdrawAbstractFactory();
            deposit_factory = deposit_abstract_factory.Get(this.Country_state);
            withdraw_factory = withdraw_abstract_factory.Get(this.Country_state);
        }

        #endregion Factory

        #region States

        public Enums.User.State.Country Country_state { get; set; }

        public void SetState()
        {
            switch (Country)
            {
                case "United Kingdom":
                    _country_state = new UKState(this);
                    break;

                case "United States":
                    _country_state = new USState(this);
                    break;

                case "Germany":
                    _country_state = new DEState(this);
                    break;

                default:
                    _country_state = new BaseState(this);
                    break;
            }

            SetFactory();
        }

        #endregion States

        #region Method

        public bool Deposit(decimal amount)
        {
            return deposit_factory.Deposit(user: this, amount: amount);
        }

        public bool Withdraw(decimal amount)
        {
            return withdraw_factory.Withdraw(user: this,amount: amount);
        }

        #endregion Method
    }
}