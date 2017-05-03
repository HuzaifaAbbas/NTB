using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NTB.Models;
using System.Data.Entity;
namespace NTB.Controllers
{
    public class LandController : Controller
    {
        NTBEntities db = new NTBEntities();
        //Create land Action starts here
        public ActionResult Create()
        {
            var landstatus = db.LandStatuses.ToList();

            ViewBag.LandStatuses = landstatus;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Land l, int landstatusid
            //string location,
            //string address,
            //string landmarks,
            //int areasize,
            //DateTime purchasedate,
            //int cost,
            //int currentvalue,
            //DateTime permitdate
            ////int landstatusid
            )
        {
            //Land l = new Land();

            //l.Location = location;
            //l.Address = address;
            //l.LandMarks = landmarks;
            //l.AreaSize = areasize;
            //l.PurchasedDate = purchasedate;
            //l.PurchasedCost = cost;
            //l.PresentCost = currentvalue;
            //l.BuildingPermitDate = permitdate;
            l.LandStatusId = landstatusid;
            //l.AdminId = Convert.ToInt32(Session["aid"]);
            //l.CreateDate = DateTime.Now;
            //db.Lands.Add(l);
            //db.SaveChanges();
            using (db)
            {
                db.Lands.Add(l);
                l.AdminId = Convert.ToInt32(Session["aid"]);
                l.CreateDate = DateTime.Now;
                db.SaveChanges();
            }
            TempData["message"] = "Land has been added to list.";
            return RedirectToAction("Land");
        }

            //List of lands
        public ActionResult Lands()
        {
            List<Land> lands = db.Lands.ToList();

            Pagination pg = new Pagination();
            pg.Lands = lands;

            return View(pg);
        }

        public ActionResult Delete(int Id)
        {
            var obj = db.Lands.Find(Id);
            db.Lands.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Lands");
        }

        public ActionResult Edit(int id)
        {
            Land l = db.Lands.Find(id);
            return View(l);
        }

        [HttpPost]
        public ActionResult Edit(Land l)
        {
            if (ModelState.IsValid)
            {
                db.Entry(l).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Lands");
            }
            return View(l);
        }


    }
}
