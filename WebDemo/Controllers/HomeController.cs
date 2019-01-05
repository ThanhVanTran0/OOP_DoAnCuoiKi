using MembershipLib;
using MembershipLib.AttributeLib;
using MembershipLib.BUS;
using MembershipLib.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

       
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [CheckPermission(Roles = "admin")]
        public ActionResult OnlyAdmin()
        {
            return View();
        }

        [CheckPermission(Users = "thang")]
        public ActionResult OnlyUser()
        {
            return View();
        }
        public ActionResult Logout()
        {
            CookieHandler.deleteCookie(this);
            return RedirectToAction("Index", "Home");
        }
        [CheckPermission(Users = "thang2", Roles = "admin")]
        public ActionResult AdminAndThang2()
        {
            return View();
        }
    }
}