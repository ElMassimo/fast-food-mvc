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
    public class RestaurantController : BaseController
    {
        protected IRestaurantServices restaurantServices = new RestaurantServices();
        protected IClientServices clientServices = new ClientServices();

        private void LoadViewBag(RestaurantListType listType)
        {
            ViewBag.ListType = listType;
            switch (listType)
            {
                case RestaurantListType.All:
                    ViewBag.PageTitle = "All restaurants";
                    ViewBag.NoRestaurants = "There are no restaurants in the system";
                    break;
                case RestaurantListType.Client:
                case RestaurantListType.Search:
                    ViewBag.PageTitle = "Restaurants in your area";
                    ViewBag.NoRestaurants = "Sorry, there are no restaurants near your location";
                    break;
            }
        }

        public ActionResult Index()
        {
            if (ClientAuthorizeAttribute.IsClient(User))
            {
                AddressModel address = clientServices.GetClient(User.Identity.Name).Address;
                LoadViewBag(RestaurantListType.Client);
                return View(restaurantServices.NearBy(address));
            }
            return RedirectToAction("All");
        }

        public ActionResult All()
        {
            LoadViewBag(RestaurantListType.All);
            return View("Index", restaurantServices.GetAll());
        }

        public ActionResult Search(AddressModel address)
        {
            if (ModelState.IsValid)
            {
                address.DependentLocalityName = GetLocalityName(address.ToString());
                if (address.DependentLocalityName != null)
                {
                    LoadViewBag(RestaurantListType.Search);
                    return View("Index", restaurantServices.NearBy(address));                    
                }
                return View("Message", new MessageModel("Restaurants", "Restaurants near by", "Sorry, the Google web service we use to obtain your location couldn't process your address"));
            }
            return View("Message", new MessageModel("Restaurants", "Restaurants near by", "Sorry, the address format is incorrect"));
        }

        public ActionResult Details(string name)
        {
            if (name != null && restaurantServices.Exists(name))
                return View("Details", restaurantServices.Get(name));

            return View("Message", new MessageModel("Restaurants", "Sorry...", "The restaurant you are looking for doesn't exist"));
        }
    }
}
