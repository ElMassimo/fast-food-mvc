using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FastFood.Dal.Repositories;
using FastFood.Core.Models;
using FastFood.Dal.EntityModels;

namespace FastFood.Core.Services
{
    public interface IOrderServices
    {
        int MakeOrder(OrderModel model, string restaurantName, string clientEmail);
        OrderModel Get(int id);
        void UpdateStatus(int orderId, OrderStatus status);
        IList<OrderModel> GetUndeliveredOrders(string nick);
        IList<OrderModel> GetClientOrders(string email);
    }

    public class OrderServices : IOrderServices
    {
        #region Constructor / Repositories
        public OrderServices()
            : this(new OrderRepository(), new ClientRepository(), new DeliveryBoyRepository(), new RestaurantRepository(), new AddressRepository())
        {
        }

        public OrderServices(IOrderRepository orderRepo, IClientRepository clientRepo, IDeliveryBoyRepository deliveryRepo, IRestaurantRepository restaurantRepo, IAddressRepository addressRepo)
        {
            _mainRepo = orderRepo;
            _clientRepo = clientRepo;
            _deliveryRepo = deliveryRepo;
            _restaurantRepo = restaurantRepo;
            _addressRepo = addressRepo;
        }

        private IOrderRepository _mainRepo;
        private IClientRepository _clientRepo;
        private IDeliveryBoyRepository _deliveryRepo;
        private IRestaurantRepository _restaurantRepo;
        private IAddressRepository _addressRepo;
        #endregion

        #region IOrderServices

        public int MakeOrder(OrderModel model, string restaurantName, string clientEmail)
        {
            model.DateOrdered = DateTime.Now;
            model.Cost = Convert.ToDecimal(Math.Pow(model.Description.Length, 2) * 0.37);
            model.Status = OrderStatus.Assigned;
            Order order = null;
            order = model.ToEntity(order);

            Client client = _clientRepo.GetSingle(c => c.Email == clientEmail);
            if (client == null)
                throw new ArgumentException("The user with email address " + clientEmail + " doesn't exist");

            Restaurant restaurant = _restaurantRepo.GetSingle(r => r.Name == restaurantName);
            int minDelivery = restaurant.DeliveryBoys.Min(d => d.SuccesfulDeliveries);
            DeliveryBoy delivery = restaurant.DeliveryBoys.Where(d => d.SuccesfulDeliveries == minDelivery).First();
            if (delivery == null)
                throw new ArgumentException("The restaurant does not have any employees that can deliver the order");

            order.DeliveryBoy = delivery;
            order.Client = client;

            _mainRepo.Add(order);
            _mainRepo.Save();

            return order.Id;
        }

        public OrderModel Get(int id)
        {
            return _mainRepo.GetSingle(o => o.Id == id).ToModel<Order, OrderModel>();
        }

        public void UpdateStatus(int orderId, OrderStatus status)
        {
            Order order = _mainRepo.GetSingle(o => o.Id == orderId);
            order.Status = (short)status;
            if (status == OrderStatus.Delivered)
            {
                order.DeliveryBoy.SuccesfulDeliveries++;
                order.DateDelivered = DateTime.Now;
            }
            _mainRepo.Save();
        }

        public IList<OrderModel> GetUndeliveredOrders(string nick)
        {
            IEnumerable<Order> orders = _mainRepo.GetAll(o => o.DeliveryBoy.Nick == nick && (o.Status == (short)OrderStatus.Assigned || o.Status == (short)OrderStatus.OnItsWay));
            return orders.ToModels<Order, OrderModel>();
        }

        public IList<OrderModel> GetClientOrders(string email)
        {
            DateTime oldestDate = DateTime.Now.AddDays(-7);
            IEnumerable<Order> orders = _mainRepo.GetAll(o => o.Client.Email == email && o.DateOrdered > oldestDate);
            return orders.ToModels<Order, OrderModel>();
        }
        #endregion
    }
}
