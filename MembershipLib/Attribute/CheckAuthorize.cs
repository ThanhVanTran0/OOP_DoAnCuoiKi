using MembershipLib.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MembershipLib.Attribute
{
    public class CheckAuthorize : FilterAttribute, IAuthorizationFilter
    {
        public string Roles { get; set;}
        public string Users;
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var a = HttpContext.Current.Request.Cookies["name"];
            if(a==null ||a.Value=="")
            {
                filterContext.Result = new RedirectResult("/Home/Login");
            }
            bool hasPermission = PUser.CheckPermission(a.Value, Roles);
            if (!hasPermission)
            {
                filterContext.Result = new RedirectResult("/Home");
            }
        }
    }
}
