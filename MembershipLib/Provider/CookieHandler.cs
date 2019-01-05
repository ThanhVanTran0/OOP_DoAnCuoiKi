using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MembershipLib.Provider
{
    public class CookieHandler
    {
        public static void setCookie(Controller c, string value)
        {
            HttpCookie cookie = new HttpCookie("name");
            cookie.Value = value;
            c.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
        }

        public static void deleteCookie(Controller c)
        {
            if(c.ControllerContext.HttpContext.Response.Cookies["name"] != null)
            {
                c.ControllerContext.HttpContext.Response.Cookies["name"].Expires = DateTime.Now.AddDays(-1);
            }
        }
    }
}
