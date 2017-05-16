using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTB.Controllers
{
    public class PaymentModeController : Controller
    {
        NTBEntities db = new NTBEntities();

        //List Done
        public ActionResult List()
        {
            return View(db.PaymentModes.ToList());
        }

        //Details Done
        public ActionResult Details(int id = 0)
        {
            return View(db.PaymentModes.Find(id));
        }

        //insert
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PaymentMode pm)
        {
            using (db)
            {
                db.PaymentModes.Add(pm);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        //Update
        public ActionResult Edit(int id = 0)
        {
            return View(db.PaymentModes.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(PaymentMode pm)
        {
            db.Entry(pm).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("List");
        }

        //Delete
        public ActionResult Delete(int id = 0)
        {
            var obj = db.PaymentModes.Find(id);
            db.PaymentModes.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("List");
         }
    }
}
