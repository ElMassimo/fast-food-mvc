using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFood.Core.Models;
using FastFood.Core.Services;
using FastFood.Front.Models;
using FastFood.Front.Security;

namespace FastFood.Front.Areas.Admin.Controllers
{
    public class RestaurantController : FastFood.Front.Controllers.RestaurantController
    {
        [AdminAuthorize]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [AdminAuthorize]
        public ActionResult New(RestaurantModel restaurant)
        {
            if(ModelState.IsValid)
            try
            {
                if (restaurantServices.Exists(restaurant.Name))
                    ModelState.AddModelError("", "A restaurant with the name " + restaurant.Name + " already exists");
                else
                {
                    restaurant.Address.DependentLocalityName = GetLocalityName(restaurant.Address.ToString());
                    restaurantServices.Add(restaurant);
                    return View("Message", new MessageModel("Create a new restaurant", "Thank you", "The restaurant was succesfully registered", "New", "Restaurant"));
                }
            }
            catch(Exception e)
            {
                return View("Message", new MessageModel("Create a new restaurant", "Oops!", e.Message));
            }
            return View(restaurant);
        }
    }
}
