using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTB.Controllers
{
    public class SaleController : Controller
    {
        NTBEntities db = new NTBEntities();

        //List Done
        public ActionResult List()
        {
            return View(db.Sales.ToList());
        }

        //Details Done
        public ActionResult Details(int id = 0)
        {
            return View(db.Sales.Find(id));
        }

        //insert
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Sale s)
        {
            using (db)
            {
                //s.Date = DateTime.Now;
                db.Sales.Add(s);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        //Update
        public ActionResult Edit(int id = 0)
        {
            return View(db.Sales.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Sale s)
        {
            db.Entry(s).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("List");
        }

        //Delete
        public ActionResult Delete(int id = 0)
        {
            return View(db.Sales.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult delete_conf(int id)
        {
            Sale s = db.Sales.Find(id);
            db.Sales.Remove(s);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
