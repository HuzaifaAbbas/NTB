using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["aid"] == null)
                return RedirectToAction("login", "account");
            return View();
        }

    }
}
