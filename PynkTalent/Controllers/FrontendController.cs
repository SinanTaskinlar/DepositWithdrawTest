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

        public ActionResult Index()
        {
            return View("~/Views/Frontend/Index.cshtml");
        }

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
            var users = StaticModel.Users.ToList();

            return Json(new { result = true,users },JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Deposit(int user_id,decimal amount)
        {
            string message = "Deposit is fail";
            var user = StaticModel.Users.FirstOrDefault(x => x.Id == user_id);

            user.SetState();

            var result = user.Deposit(amount: amount);

            if ( result )
            {
                message = "Deposit is successful";
            }

            return Json(new { result,message,user.Balance });
        }

        [HttpPost]
        public JsonResult Withdraw(int user_id,decimal amount)
        {
            string message = "Withdraw is fail";
            var user = StaticModel.Users.FirstOrDefault(x => x.Id == user_id);

            user.SetState();

            var result = user.Withdraw(amount: amount);

            if ( result )
            {
                message = "Withdraw is successful";
            }

            return Json(new { result,message,user.Balance });
        }
    }
}