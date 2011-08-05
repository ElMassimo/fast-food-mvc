using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using FastFood.Core.Models;
using FastFood.Core.Services;

namespace FastFood.Services
{    
    public class RestaurantServices : IRestaurantServices
    {
        private static IOrderServices orderServices;

        public RestaurantServices()
        {
            orderServices = new OrderServices();
        }

        public int MakeOrder(OrderModel order, string restaurantName, string clientEmail)
        {
            try
            {
                return orderServices.MakeOrder(order, restaurantName, clientEmail);
            }
            catch
            {
                return -1;
            }
        }

        public OrderModel GetFullOrderDetail(int orderId)
        {
            try
            {
                return orderServices.Get(orderId);
            }
            catch
            {
                return null;
            }
        }
    }
}
