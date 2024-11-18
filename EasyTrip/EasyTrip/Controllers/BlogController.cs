using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyTrip.Models.Classes;

namespace EasyTrip.Controllers
{
    public class BlogController : Controller
    {
      
        Context db = new Context();
        BlogComment by = new BlogComment();
        [Authorize]
        public ActionResult Index()
        {
            // var result = db.Blogs.ToList();
            by.Deger1 = db.Blogs.ToList();
            by.Deger3 = db.Blogs.OrderByDescending(b => b.BlogId).Take(3).ToList();

            return View(by);
        }
        public ActionResult BlogDetail(int id)
        {
           

            // var blogbul=db.Blogs.Where(x=>x.BlogId==id).ToList();
            by.Deger1 = db.Blogs.Where(x => x.BlogId == id).ToList();
            by.Deger2 = db.Comments.Where(x => x.BlogId == id).ToList();
            return View(by);
        }



        [HttpGet]
        public PartialViewResult CommentCreate(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }




        [HttpPost]
        public PartialViewResult CommentCreate(Comment y)
        {
            db.Comments.Add(y);
            db.SaveChanges();
            return PartialView();
        }
    }
}