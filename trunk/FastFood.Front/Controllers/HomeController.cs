using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFood.Core.Security;
using FastFood.Core.Services;
using FastFood.Core.Models;
using FastFood.Dal.EntityModels;
using FastFood.Front.Security;

namespace FastFood.Front.Controllers
{
    public class HomeController : BaseController
    {
        public virtual ActionResult Index()
        {
            ViewBag.Message = "Welcome to the fastest delivery service!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
