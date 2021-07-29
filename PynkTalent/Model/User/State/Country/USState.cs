using PynkTalent.Models.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PynkTalent.Models.User.Country.State
{
    public class USState : BaseState
    {
        public USState(UserModel user) : base(user)
        {
            user.Country_state = Enums.User.State.Country.UnitedStates;
        }
    }
}