using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyTrip.Models.Classes;

namespace EasyTrip.Controllers
{
    public class ContactController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            var values = db.Adresses.ToList();
            return View(values);
        }

        public ActionResult ContactList()
        {
            var values=db.Adresses.ToList();
            return View(values);
        }

       
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Adress adress)
        {
            if (ModelState.IsValid)
            {
                db.Adresses.Add(adress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adress);
        }

       
        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var adress = db.Adresses.Find(id);
            if (adress == null)
            {
                return HttpNotFound();
            }
            return View(adress);
        }

        [HttpPost]
        public ActionResult UpdateContact(Adress adress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adress).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adress);
        }

       
        public ActionResult DeleteContact(int id)
        {
            var adress = db.Adresses.Find(id);
            if (adress == null)
            {
                return HttpNotFound();
            }

            db.Adresses.Remove(adress);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}