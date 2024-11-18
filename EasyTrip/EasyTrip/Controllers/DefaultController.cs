using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyTrip.Models.Classes;

namespace EasyTrip.Controllers
{
    public class DefaultController : Controller
    {
       Context db = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var result = db.Blogs.Take(10).ToList();
            return View(result);
        }
       public PartialViewResult Partial1()
        {
            var result = db.Blogs.ToList();
            return PartialView(result);
        }
        public PartialViewResult Partial2() {
            var result = db.Blogs.Take(3).ToList();
            return PartialView(result);
        
        }
        public PartialViewResult Partial3()
        {
            var result = db.Blogs.Take(3).OrderByDescending(x=>x.BlogId).ToList();
            return PartialView(result);

        }


    }
}