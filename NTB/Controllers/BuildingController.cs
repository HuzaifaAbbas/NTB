using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NTB.Controllers
{
    public class BuildingController : Controller
    {
        NTBEntities db = new NTBEntities();

        //List Done
        public ActionResult List()
        {
            return View(db.Buildings.ToList());
        }

        //Details Done
        public ActionResult Details(int id = 0)
        {
            return View(db.Buildings.Find(id));
        }

        //insert
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Building b)
        {
            using (db)
            {
                db.Buildings.Add(b);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        //Update
        public ActionResult Edit(int id =0)
        {
            return View(db.Buildings.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Building b)
        {
            db.Entry(b).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("List");
        }
        
        //Delete
        public ActionResult Delete(int id = 0)
        {
            return View(db.Buildings.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult delete_conf(int id)
        {
            Building b = db.Buildings.Find(id);
            db.Buildings.Remove(b);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
