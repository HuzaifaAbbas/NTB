﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTB.Controllers
{
    public class RoomController : Controller
    {
        NTBEntities db = new NTBEntities();

        //List Done
        public ActionResult List()
        {
            return View(db.Rooms.ToList());
        }

        //Details Done
        public ActionResult Details(int id = 0)
        {
            return View(db.Rooms.Find(id));
        }

        //insert
        public ActionResult Create()
        {
            var floor = db.Floors.ToList();
            ViewBag.Floor = floor;
            var type = db.RoomTypes.ToList();
            ViewBag.Type = type;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Room r)
        {
            using (db)
            {
                db.Rooms.Add(r);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        //Update
        public ActionResult Edit(int id = 0)
        {
            //var floor = db.Floors.ToList();
            //ViewBag.Floor = floor;
            //var type = db.RoomTypes.ToList();
            //ViewBag.Type = type;

            return View(db.Rooms.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Room r)
        {
            db.Entry(r).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("List");
        }

        //Delete
        public ActionResult Delete(int id)
        {
            var obj = db.Rooms.Find(id);
            db.Rooms.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
