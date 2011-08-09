using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Text.RegularExpressions;
using System.Configuration;

namespace FastFood.Front.Controllers
{
    public class BaseController : Controller
    {
        private Regex locationExpression = new Regex("\"DependentLocalityName\" : \"(.+?)\",");

        public string GetLocalityName(string strAddress)
        {
            try
            {
                string key = ConfigurationManager.AppSettings["GoogleGeocodingKey"];
                string servicePath = String.Format("http://maps.google.com/maps/geo?q={0}&output=json&key={1}&sensor=false", strAddress, key);
                WebClient client = new WebClient();
                string result = client.DownloadString(servicePath);
                Match match = locationExpression.Match(result);
                if (match.Success)
                    return match.Groups[1].Value;
            }
            catch {}
            return null;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string area = filterContext.RouteData.DataTokens["area"] as string;
            ViewBag.IsAdmin = area != null && area.Equals("Admin", StringComparison.OrdinalIgnoreCase);
            ViewBag.IsAdminLogged = filterContext.HttpContext.User.IsInRole("Administrators");
            ViewBag.IsAdmin |= ViewBag.IsAdminLogged;
            base.OnActionExecuting(filterContext);
        }
    }
}
