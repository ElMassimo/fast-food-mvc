using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FastFood.Dal.Repositories;
using FastFood.Dal.EntityModels;
using FastFood.Core.Models;

namespace FastFood.Core.Services
{
    public interface IDeliveryServices : IServices<DeliveryBoyModel>
    {
        bool IsDeliveryBoy(string nick);
        DeliveryBoyModel GetDeliveryBoy(string nick);
        IList<DeliveryBoyModel> GetAllByRestaurant(string restaurantName);
    }

    public class DeliveryServices : BaseServices<DeliveryBoy, DeliveryBoyModel>, IDeliveryServices
    {
        #region Constructors / Repositories

        public DeliveryServices()
            : this(new OrderRepository(), new DeliveryBoyRepository(), new DeliveryBoyRepository(), new RestaurantRepository(), new AddressRepository())
        {
        }

        public DeliveryServices(IOrderRepository orderRepo, IDeliveryBoyRepository clientRepo, IDeliveryBoyRepository deliveryRepo, IRestaurantRepository restaurantRepo, IAddressRepository addressRepo)
            : base(deliveryRepo)
        {
            _orderRepo = orderRepo;
            _clientRepo = clientRepo;
            _restaurantRepo = restaurantRepo;
            _addressRepo = addressRepo;
        }

        private IOrderRepository _orderRepo;
        private IDeliveryBoyRepository _clientRepo;
        private IRestaurantRepository _restaurantRepo;
        private IAddressRepository _addressRepo;

        #endregion

        #region IServices<DeliveryBoy>

        public void Add(DeliveryBoyModel model)
        {
            DeliveryBoy deliveryBoy = model.ToEntity<DeliveryBoyModel,DeliveryBoy>();
            deliveryBoy.Restaurant = _restaurantRepo.GetSingle(r => r.Name == model.Restaurant.Name);
            _mainRepo.Add(deliveryBoy);
            _mainRepo.Save();
        }

        public void Delete(DeliveryBoyModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(DeliveryBoyModel model)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDeliveryBoyServices
        
        public bool IsDeliveryBoy(string nick)
        {
            return _mainRepo.Any(d => d.Nick == nick);
        }

        public DeliveryBoyModel GetDeliveryBoy(string nick)
        {
            DeliveryBoy deliveryBoy = _mainRepo.GetSingle(d => d.Nick == nick);

            if (deliveryBoy == null)
                return null;

            return deliveryBoy.ToModel<DeliveryBoy,DeliveryBoyModel>();
        }

        public IList<DeliveryBoyModel> GetAllByRestaurant(string restaurantName)
        {
            IEnumerable<DeliveryBoy> deliveryBoys = _mainRepo.GetAll(d => d.Restaurant.Name == restaurantName);
            return deliveryBoys.ToModels<DeliveryBoy, DeliveryBoyModel>();
        }
        #endregion
    }
}
