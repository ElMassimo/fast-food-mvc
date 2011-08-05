using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using FastFood.Core.Models;

namespace FastFood.Services
{
    [ServiceContract]
    public interface IRestaurantServices
    {
        // Services for other restaurants
        [OperationContract]
        int MakeOrder(OrderModel order, string restaurantName, string clientEmail);

        [OperationContract]
        OrderModel GetFullOrderDetail(int orderId);
    }
}
