using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFood.Core.Security;
using System.Security.Principal;

namespace FastFood.Front.Security
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ClientAuthorizeAttribute : AuthorizeAttribute
    {
        private static ISecurity _security = new ClientSecurity();

        public static bool IsClient(IPrincipal user)
        {
            if (!user.Identity.IsAuthenticated || user.Identity.Name == null)
                return false;

            return _security.IsUser(user.Identity.Name);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return IsClient(httpContext.User);
        }        
    }
}