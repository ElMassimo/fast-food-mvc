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
    public class DeliveryController : Controller
    {
        private IDeliveryServices deliveryServices = new DeliveryServices();
        private IRestaurantServices restaurantServices = new RestaurantServices();

        public ActionResult Add(string restaurantName)
        {
            if (restaurantServices.Exists(restaurantName))
                return View(new RegisterDeliveryBoyModel()
                {
                    Restaurant = new RestaurantModel() { Name = restaurantName }
                });
            return View("Message", new MessageModel("Make an order", "Sorry...", "The restaurant you are looking for doesn't exist", "Index", "Restaurant"));
        } 
        
        [HttpPost]
        public ActionResult Add(DeliveryBoyModel model)
        {
            if(ModelState.IsValid)
            try
            {
                if (restaurantServices.Exists(model.Restaurant.Name))
                {
                    deliveryServices.Add(model);
                    return View("Message", new MessageModel("Add delivery boy", "Congratulations!", "The restaurant has a new employee aboard", "Index", "Restaurant"));
                }
                return View("Message", new MessageModel("Make an order", "Sorry...", "The restaurant you are looking for doesn't exist", "Index", "Restaurant"));
            }
            catch(Exception e)
            {
                return View("Message", new MessageModel("Add delivery boy", "Sorry...", e.Message));
            }
            return View(model);
        }
    }
}
