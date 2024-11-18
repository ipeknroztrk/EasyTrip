using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyTrip.Models.Classes;

namespace EasyTrip.Controllers
{
    public class AdminController : Controller
    {
        Models.Classes.Context c = new Models.Classes.Context();

        [Authorize]
        public ActionResult Index()
        {
            var result = c.Blogs.ToList();
            return View(result);
        }

        public ActionResult Create()
        {
            return View(); // View'e boş bir model gönderiyoruz
        }

        [HttpPost]
        public ActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                // Blog modeline yeni veriler ekleniyor
                c.Blogs.Add(blog);
                c.SaveChanges(); // Veritabanına kaydediliyor
                return RedirectToAction("Index"); // Başarıyla tamamlanınca Index sayfasına yönlendir
            }

            // Eğer model geçerli değilse, form tekrar aynı modelle gösterilir
            return View(blog);
        }



        public ActionResult Edit(int id)
        {
            var blog = c.Blogs.Find(id);
            
            return View("Edit",blog);
        }

        [HttpPost]
        
        public ActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                var existingBlog = c.Blogs.FirstOrDefault(b => b.BlogId == blog.BlogId);
               
                    existingBlog.Title = blog.Title;
                    existingBlog.BlogImgUrl = blog.BlogImgUrl;
                    existingBlog.Description = blog.Description;
                    existingBlog.Date = blog.Date;

                    c.SaveChanges();
                    return RedirectToAction("Index");
               
            }
            return View(blog);
        }



        public ActionResult Delete(int id)
        {
            var blog = c.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (blog != null)
            {
                c.Blogs.Remove(blog);
                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }

      
        public ActionResult Details(int id)
        {
           
            var blog = c.Blogs.Find(id);

          
            return View(blog);
        }

    }
}
