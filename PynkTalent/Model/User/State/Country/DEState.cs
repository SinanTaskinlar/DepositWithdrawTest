using PynkTalent.Models.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PynkTalent.Models.User.Country.State
{
    public class DEState : BaseState
    {
        public DEState(UserModel user) : base(user)
        {
            user.country_state = Enums.User.State.Country.Germany;
        }
    }
}