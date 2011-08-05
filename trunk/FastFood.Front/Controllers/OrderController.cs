using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFood.Core.Models;
using FastFood.Core.Services;
using FastFood.Front.Models;
using FastFood.Front.Security;

namespace FastFood.Front.Controllers
{
    public class OrderController : Controller
    {
        private IOrderServices orderServices = new OrderServices();
        private IRestaurantServices restaurantServices = new RestaurantServices();

        [ClientAuthorize]
        public ActionResult Index()
        {

            return View();
        }

        [ClientAuthorize]
        public ActionResult Details(int id)
        {
            return View();
        }
        
        [ClientAuthorize]
        public ActionResult Make(string restaurantName)
        {
            if (restaurantServices.Exists(restaurantName))
                return View();
            return View("Message", new MessageModel("Make an order", "Sorry...", "The restaurant you are looking for doesn't exist", "Index", "Restaurant"));
        }

        [HttpPost]
        [ClientAuthorize]
        public ActionResult Make(OrderModel order, string restaurantName)
        {
            if(ModelState.IsValid && User.Identity.IsAuthenticated)
            try
            {
                if (restaurantServices.Exists(restaurantName))
                {
                    orderServices.MakeOrder(order, restaurantName, User.Identity.Name);
                    return View("Message", new MessageModel("Make an order", "Food is on the way...", "Your order was succesfully registered!"));
                }
                return View("Message", new MessageModel("Make an order", "Sorry...", "The restaurant you are looking for doesn't exist", "Index", "Restaurant"));
            }
            catch(Exception e)
            {
                return View("Message", new MessageModel("Make an order", "Sorry...", e.Message));
            }
            return View(order);
        }        
    }
}
