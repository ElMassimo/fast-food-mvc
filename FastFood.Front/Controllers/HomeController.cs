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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AddressModel address = new AddressModel()
            {
                ApartmentNumber = 104,
                Number = 520,
                Street = "Maggiolo",
                City = "Montevideo",
                State = "Montevideo",
                Country = "Uruguay",
                PostalCode = 11200
            };
            ClientModel client = new ClientModel()
            {
                Address = address,
                Email = "maximomussini@gmail.com",
                FirstName = "Maximo",
                LastName = "Mussini",
                Password = "holanda",
                Phone = "099479451"                
            };
            IClientServices services = new ClientServices();
            services.Add(client);

            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        [ClientAuthorize]
        public ActionResult About()
        {
            return View();
        }
    }
}
