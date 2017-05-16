using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NTB.Models;

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
            var land = db.Lands.ToList();
            ViewBag.Land = land;
            var status = db.BuildingStatuses.ToList();
            ViewBag.Status = status;
            var type = db.BuildingTypes.ToList();
            ViewBag.Type = type;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Building b, int BuildingStatusId, int BuildTypeId)
        {
            using (db)
            {
                b.BuildingStatusId = BuildingStatusId;
                b.BuildTypeId = BuildTypeId;
                db.Buildings.Add(b);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        //Update
        public ActionResult Edit(int id = 0)
        {
            var land = db.Lands.ToList();
            ViewBag.Land = land;
            return View(db.Buildings.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Building b)
        {
            try
            {
                db.Entry(b).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                TempData["message"] = "Land Not Found" +e;
                return RedirectToAction("Edit");
            }
            
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
