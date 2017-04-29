using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTB.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            NTBEntities db = new NTBEntities();
            var admin = db.Admins.FirstOrDefault(u => u.Email == email && u.Password == password);

            if(email == admin.Email && password == admin.Password)
            {
                Session["aid"] = admin.Id;
                Session["aname"] = admin.Name;
                Session["aemail"] = admin.Email;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "InvalidLogin/Password";
                return View("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login", "Account");
        }
    }
}
