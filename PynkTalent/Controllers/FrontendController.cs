using PynkTalent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PynkTalent.Controllers
{
    public class FrontendController : Controller
    {
        // GET: Frontend
        public ActionResult Deposit()
        {
            return View("~/Views/Frontend/Deposit.cshtml");
        }

        public ActionResult Withdraw()
        {
            return View("~/Views/Frontend/Withdraw.cshtml");
        }

        public JsonResult Users()
        {
            var users = StaticModel.users.ToList();

            return Json(new { result = true,users },JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Deposit(int user_id,decimal amount)
        {
            string message = "Deposit is fail";
            var user = StaticModel.users.FirstOrDefault(x => x.id == user_id);

            user.SetState();

            var result = user.Deposit(amount: amount);

            if ( result )
            {
                message = "Deposit is successful";
            }

            return Json(new { result,message,user.balance });
        }
    }
}