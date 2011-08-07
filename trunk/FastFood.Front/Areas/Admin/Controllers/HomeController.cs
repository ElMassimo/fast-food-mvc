using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFood.Front.Security;

namespace FastFood.Front.Areas.Admin.Controllers
{
    public class HomeController : FastFood.Front.Controllers.HomeController
    {
        [AdminAuthorize]
        public override ActionResult Index()
        {
            ViewBag.Message = "Welcome to the administrative site!";
            return View();
        }
    }
}
