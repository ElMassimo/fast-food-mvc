using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFood.Core.Models;
using FastFood.Core.Services;
using FastFood.Front.Models;
using FastFood.Front.Security;
using FastFood.Front.Controllers;

namespace FastFood.Front.Areas.Admin.Controllers
{
    public class DeliveryController : BaseController
    {
        private IDeliveryServices deliveryServices = new DeliveryServices();
        private IRestaurantServices restaurantServices = new RestaurantServices();

        [AdminAuthorize]
        public ActionResult Add(string restaurantName)
        {
            if (restaurantServices.Exists(restaurantName))
                return View(new RegisterDeliveryBoyModel(restaurantName));
            return View("Message", new MessageModel("Make an order", "Sorry...", "The restaurant you are looking for doesn't exist", "Index", "Restaurant"));
        }

        [HttpPost]
        [AdminAuthorize]
        public ActionResult Add(RegisterDeliveryBoyModel model)
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

        [AdminAuthorize]
        public ActionResult Employees(string restaurantName)
        {
            if(restaurantServices.Exists(restaurantName))
            {
                ViewBag.RestaurantName = restaurantName;
                IList<DeliveryBoyModel> employees = deliveryServices.GetAllByRestaurant(restaurantName);
                return View(employees);
            }
            return View("Message", new MessageModel("Restaurant employees", "Sorry...", "The restaurant you are looking for doesn't exist"));
        }
    }
}
