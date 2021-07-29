using PynkTalent.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PynkTalent.Models.State
{
    public class BaseState
    {
        public BaseState(UserModel user)
        {
            user.Country_state = Enums.User.State.Country.All;
        }
    }
}