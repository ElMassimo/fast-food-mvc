﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFood.Core.Security;

namespace FastFood.Front.Security
{
    public class DeliveryAuthorizeAttribute : AuthorizeAttribute
    {
        private ISecurity _security = new DeliveryBoySecurity();

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated || httpContext.User.Identity.Name == null)
                return false;

            // Obtener la información necesaria
            // httpContext.Request.RequestContext.RouteData.Values["id"]
            // httpContext.Request["id"]

            // Realizar algún chequeo

            return _security.IsUser(httpContext.User.Identity.Name);
        }
    }
}