using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FastFood.Front.Security
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.User.Identity.IsAuthenticated && httpContext.User.IsInRole("Administrators");
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult("Admin_login", 
                new RouteValueDictionary { { "ReturnUrl", filterContext.HttpContext.Request.RawUrl } });
            }
        }
    }
}