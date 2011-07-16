using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FastFood.Dal.Repositories;

namespace FastFood.Core.Services
{
    public interface IOrderServices
    {

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
            _orderRepo = orderRepo;
            _clientRepo = clientRepo;
            _deliveryRepo = deliveryRepo;
            _restaurantRepo = restaurantRepo;
            _addressRepo = addressRepo;
        }

        private IOrderRepository _orderRepo;
        private IClientRepository _clientRepo;
        private IDeliveryBoyRepository _deliveryRepo;
        private IRestaurantRepository _restaurantRepo;
        private IAddressRepository _addressRepo;
        #endregion
    }
}
