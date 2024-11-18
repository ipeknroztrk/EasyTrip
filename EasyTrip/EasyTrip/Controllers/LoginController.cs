using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EasyTrip.Models.Classes;

namespace EasyTrip.Controllers
{
    public class LoginController : Controller
    {
        Context db = new Context();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin adm)
        {
            var bilgiler = db.Admins.FirstOrDefault(x => x.Username == adm.Username && x.Password == adm.Password);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Username, false);
                Session["Username"] = bilgiler.Username.ToString();

                return RedirectToAction("Index", "Admin");
            }
            else { return View(); }
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}