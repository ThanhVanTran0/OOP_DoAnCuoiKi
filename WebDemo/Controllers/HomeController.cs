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
        BUS<User> user = Moudle.INSTANCE.GetModel<BUS<User>>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [CheckAuthorize(Roles="admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CheckLogin(string username, string password)
        {
            if(PUser.Login(username, password))
            {
                HttpCookie cookie = new HttpCookie("name");
                cookie.Value = username;
                this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                return RedirectToAction("Contact");

            }
            else
            {
                ViewBag.Error = true;
                return View("Login");
            }
        }
    }
}