using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFood.Core.Models;
using FastFood.Core.Services;
using FastFood.Front.Models;

namespace FastFood.Front.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantServices restaurantServices = new RestaurantServices();
               
        public ActionResult Index()
        {
            return View(restaurantServices.GetAll());
        }
        
        public ActionResult Search(AddressModel address)
        {
            if (ModelState.IsValid && restaurantServices.AnyNearBy(address))
            {                
                return View("Index", restaurantServices.NearBy(address));
            }
            return View("Message", new MessageModel("Restaurants", "Restaurants near by", "Sorry, there are no restaurants that deliver to your address"));
        }
        
        public ActionResult New()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult New(RestaurantModel restaurant)
        {
            if(ModelState.IsValid)
            try
            {
                if (restaurantServices.Exists(restaurant.Name))
                    ModelState.AddModelError("", "A restaurant with the name " + restaurant.Name + " already exists");
                else
                {
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

        public ActionResult Details(string name)
        {
            if (name != null && restaurantServices.Exists(name))
                return View("Details", restaurantServices.Get(name));

            return View("Message", new MessageModel("Restaurants", "Sorry...", "The restaurant you are looking for doesn't exist"));
        }
    }
}
