using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTB.Controllers
{
    public class FloorController : Controller
    {
        NTBEntities db = new NTBEntities();

        //List Done
        public ActionResult List()
        {
            return View(db.Floors.ToList());
        }

        //Details Done
        public ActionResult Details(int id = 0)
        {
            return View(db.Floors.Find(id));
        }

        //insert
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Floor f)
        {
            using (db)
            {
                db.Floors.Add(f);
                //db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        //Update
        public ActionResult Edit(int id = 0)
        {
            return View(db.Floors.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Floor f)
        {
            db.Entry(f).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("List");
        }

        //Delete
        public ActionResult Delete(int id = 0)
        {
            return View(db.Floors.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult delete_conf(int id)
        {
            Floor f = db.Floors.Find(id);
            db.Floors.Remove(f);
            db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}
