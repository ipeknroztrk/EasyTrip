using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyTrip.Models.Classes;

namespace EasyTrip.Controllers
{
    public class CommentController : Controller
    {
        
        Context db = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var result = db.Comments.ToList();
            return View(result);
        }
        public ActionResult DeleteComment(int id)
        {
            var comment = db.Comments.FirstOrDefault(x => x.CommentId == id);
          
                db.Comments.Remove(comment);
                db.SaveChanges();
            
            return RedirectToAction("Index");

        }



        public ActionResult UpdateComment(int id)
        {
            // Yorum verisini ID'ye göre buluyoruz.
            var comment = db.Comments.Find(id);

            if (comment == null)
            {
                // Eğer yorum bulunmazsa hata sayfasına yönlendiriyoruz.
                return HttpNotFound("Yorum bulunamadı.");
            }

            return View("UpdateComment", comment);
        }

        [HttpPost]
        public ActionResult UpdateComment(Comment comment)
        {
            if (comment == null)
            {
                return HttpNotFound("Geçersiz veri.");
            }

            // Yorumu veritabanından ID'si ile buluyoruz.
            var existingComment = db.Comments.Find(comment.CommentId);

            if (existingComment == null)
            {
                return HttpNotFound("Yorum bulunamadı.");
            }

            // Yorum verilerini güncelliyoruz.
            existingComment.Username = comment.Username;
            existingComment.Mail = comment.Mail;
            existingComment.Comments = comment.Comments;

            // Veritabanında değişiklikleri kaydediyoruz.
            db.SaveChanges();

            // Yorumlar sayfasına yönlendirme yapıyoruz.
            return RedirectToAction("Index", "Comment");
        }

    }
}