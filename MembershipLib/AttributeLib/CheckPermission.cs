using MembershipLib.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MembershipLib.AttributeLib
{
    public class CheckPermission : FilterAttribute, IAuthorizationFilter
    {
        public string Roles { get; set; }
        public string Users;
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var a = HttpContext.Current.Request.Cookies["name"];
            if (a == null || a.Value == "")
            {
                filterContext.Result = new RedirectResult("/Login");
                return;
            }
            if (Roles != null && Roles != "" || Users != null && Users != "")
            {
                bool hasPermission = false;
                if (Users != null && Users != "")
                {
                    if (!hasPermission)
                    {
                        string[] arr = Users.Split(',');
                        hasPermission = arr.Contains(a.Value);
                    }
                }
                if (Roles != null && Roles != "")
                {
                    if (!hasPermission)
                        hasPermission = PUser.CheckPermission(a.Value, Roles);
                }
                if (!hasPermission)
                {
                    filterContext.Result = new RedirectResult("/Home");
                    return;
                }
            }

        }
    }
}

