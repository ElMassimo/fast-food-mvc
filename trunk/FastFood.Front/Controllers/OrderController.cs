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
    public class OrderController : BaseController
    {
        private IOrderServices orderServices = new OrderServices();
        private IRestaurantServices restaurantServices = new RestaurantServices();

        [ClientAuthorize]
        public ActionResult Index()
        {
            IList<OrderModel> orders = orderServices.GetClientOrders(User.Identity.Name);
            if(orders.Count > 0)
                return View(orders);
            return View("Message", new MessageModel("Recent orders", "Recent orders", "You haven't made any orders during the last seven days", "Index", "Restaurant"));
        }

        [ClientAuthorize]
        public ActionResult Details(int id)
        {
            try
            {
                OrderModel order = orderServices.Get(id);
                if (order.Client.Email == User.Identity.Name)
                    return View(order);
                else
                    return View("Message", new MessageModel("View order detail", "Sorry...", "You are not allowed to view that order", "Index", "Order"));
            }
            catch
            {
                return View("Message", new MessageModel("Make an order", "Sorry...", "The order you are looking for doesn't exist"));
            }
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
            if(ModelState.IsValid)
            try
            {
                if (restaurantServices.Exists(restaurantName))
                {
                    orderServices.MakeOrder(order, restaurantName, User.Identity.Name);
                    return View("Message", new MessageModel("Make an order", "Food is on the way...", "Your order was succesfully registered!", "Index", "Order"));
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
