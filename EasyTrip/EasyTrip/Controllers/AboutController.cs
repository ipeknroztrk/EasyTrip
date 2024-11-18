using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyTrip.Models.Classes;

namespace EasyTrip.Controllers
{
    public class AboutController : Controller
    {
       
        Context db = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var result = db.Abouts.ToList();
            return View(result);
        }
        public ActionResult AboutList()
        {
            var result = db.Abouts.ToList();
            return View(result);
        }


        public ActionResult DeleteAbout(int id)
        {
            var About = db.Abouts.FirstOrDefault(x => x.AboutId == id);

            db.Abouts.Remove(About);
            db.SaveChanges();

            return RedirectToAction("Index");

        }



        public ActionResult UpdateAbout(int id)
        {
          
            var About = db.Abouts.Find(id);

            if (About == null)
            {
               
                return HttpNotFound("Yorum bulunamadı.");
            }

            return View("UpdateAbout", About);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About About)
        {
            if (About == null)
            {
                return HttpNotFound("Geçersiz veri.");
            }

           
            var existingAbout = db.Abouts.Find(About.AboutId);

            if (existingAbout == null)
            {
                return HttpNotFound("Yorum bulunamadı.");
            }

            
            existingAbout.ImageUrl = About.ImageUrl;
            existingAbout.Description = About.Description;
           

           
            db.SaveChanges();

          
            return RedirectToAction("Index", "About");
        }

    }
}