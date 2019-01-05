using MembershipLib.AttributeLib;
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
                HttpCookie cookie = new HttpCookie("name");
                cookie.Value = username;
                this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
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