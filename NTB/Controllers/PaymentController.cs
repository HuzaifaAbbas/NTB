using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTB.Controllers
{
    public class PaymentController : Controller
    {
        NTBEntities db = new NTBEntities();

        //List Done
        public ActionResult List()
        {
            return View(db.Payments.ToList());
        }

        //Details Done
        public ActionResult Details(int id = 0)
        {
            return View(db.Payments.Find(id));
        }

        //insert
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Payment p)
        {
            using (db)
            {
                db.Payments.Add(p);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        //Update
        public ActionResult Edit(int id = 0)
        {
            return View(db.Payments.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Payment p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("List");
        }

        //Delete
        public ActionResult Delete(int id = 0)
        {
            return View(db.Payments.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult delete_conf(int id)
        {
            Payment p = db.Payments.Find(id);
            db.Payments.Remove(p);
            db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}
