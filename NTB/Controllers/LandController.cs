using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NTB.Models;
namespace NTB.Controllers
{
    public class LandController : Controller
    {
        NTBEntities db = new NTBEntities();

        //List Done
        public ActionResult List()
        {
            return View(db.Lands.ToList());
        }

        //public ActionResult ListofBuilding()
        //{
        //    List<Building> buildings = db.Buildings.ToList();

        //    buildings = db.Buildings.Where(x => x.LandId.Equals(buildings.)).ToList();
        //    return View();
        //}

        //Details Done
        public ActionResult Details(int id = 0)
        {
            return View(db.Lands.Find(id));
        }

        //insert
        public ActionResult Create()
        {
            var status = db.LandStatuses.ToList();
            ViewBag.Status = status;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Land l, int LandStatusId)
        {
            try
            {
                using (db)
                {
                    l.LandStatusId = LandStatusId;
                    l.AdminId = Convert.ToInt32(Session["aid"]);
                    l.CreateDate = DateTime.Now;
                    db.Lands.Add(l);
                    db.SaveChanges();
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                Exception raise = e;
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
                //TempData["message"] = "Something is wrong! " + e;
            }
            return RedirectToAction("List");
        }

        //Update
        public ActionResult Edit(int id = 0)
        {
            var status = db.LandStatuses.ToList();
            ViewBag.Status = status;
            return View(db.Lands.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Land l)
        {

            try
            {
                db.Entry(l).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var item in e.EntityValidationErrors)
                {
                   // 
                }
                throw;
            }
            return RedirectToAction("List");
        }

        //Delete
        public ActionResult Delete(int id)
        {
            try
            {
                var obj = db.Lands.Find(id);
                db.Lands.Remove(obj);
                db.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                @TempData["message"] = " land might be associated with a building. " +e;
            }
            return RedirectToAction("List");
        }

        //[HttpPost, ActionName("Delete")]
        //public ActionResult delete_conf(int id)
        //{
        //    Land l = db.Lands.Find(id);
        //    db.Lands.Remove(l);
        //    db.SaveChanges();
        //    return RedirectToAction("List");
        //}
    }
}
