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
    public class Authenticated : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var a = HttpContext.Current.Request.Cookies["name"];
            if(a != null)
            {
                if (a.Value != "")
                {
                    User u = new User();
                    u.Name = a.Value;
                    if (PUser.CheckValidate(u))
                    {
                        filterContext.Result = new RedirectResult("/Home");
                    }
                }
                
            }
        }
    }
}
