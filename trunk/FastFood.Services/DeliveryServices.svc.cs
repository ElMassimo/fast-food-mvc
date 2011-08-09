using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using FastFood.Core.Models;
using FastFood.Core.Services;
using FastFood.Core.Security;

namespace FastFood.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class DeliveryServices : IDeliveryServices
    {
        #region Constructor/Variables
        private static IOrderServices orderServices;
        private static ISecurity security;

        public DeliveryServices()
        {
            orderServices = new OrderServices();
            security = new DeliveryBoySecurity();
        }
        #endregion


        public IList<OrderHeader> GetUndeliveredOrders(string nick, string password)
        {
            if (!security.ValidateUser(nick, password))
                return null;
         
            IEnumerable<OrderModel> orders = orderServices.GetUndeliveredOrders(nick);
            IList<OrderHeader> headers = new List<OrderHeader>();
            foreach (OrderModel order in orders)
            {
                OrderHeader header = new OrderHeader(order.Id, String.Format("Description: {0}\nLocation: {1}", order.Description, order.Client.Address.DependentLocalityName));
                headers.Add(header);
            }
            return headers;
        }

        public OrderDetail GetOrderDetail(int orderId)
        {
            try
            {
                OrderModel order = orderServices.Get(orderId);
                return new OrderDetail()
                {
                    Id = order.Id,
                    Status = (int)order.Status,
                    Description =  order.Description,
                    DateOrdered = order.DateOrdered,
                    Cost = order.Cost,
                    Address = order.Client.Address.ToString()
                };
            }
            catch
            {
                return null;
            }
        }

        public bool DeliverOrder(string nick, string password, int orderId, int orderStatus)
        {
            if (!security.ValidateUser(nick, password))
                return false;
            try
            {
                orderServices.UpdateStatus(orderId, (OrderStatus)orderStatus);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
