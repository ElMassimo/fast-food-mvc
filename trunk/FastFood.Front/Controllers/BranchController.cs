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
            return View();
        }
        
        public ActionResult Search(AddressModel address)
        {
            if (ModelState.IsValid)
            {
                return View("Index", restaurantServices.NearBy(address));
            }
            else
            {
                return View("Message", new MessageModel("Restaurants", "Restaurants near by", "Sorry, there are no restaurants that deliver to your address"));
            }
        }
        
        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
 
        public ActionResult Edit(int id)
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
