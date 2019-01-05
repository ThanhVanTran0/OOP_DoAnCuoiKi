using MembershipLib.Attribute;
using MembershipLib.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDemo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [Authenticated]
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult CheckLogin(string username, string password)
        {
            if (PUser.Login(username, password))
            {
                CookieHandler.setCookie(this, username);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.Error = true;
                return View("Login");
            }
        }
    }
}