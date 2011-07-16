using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FastFood.Dal.Repositories;
using FastFood.Dal.EntityModels;
using FastFood.Core.Models;

namespace FastFood.Core.Services
{
    public interface IRestaurantServices : IServices<RestaurantModel>
    {
        bool Exists(string name);
        RestaurantModel Get(string name);
        IEnumerable<RestaurantModel> NearBy(AddressModel address);
    }

    public class RestaurantServices : BaseServices<Restaurant, RestaurantModel>, IRestaurantServices
    {
        #region Constructor / Repositories
        public RestaurantServices()
            : this(new OrderRepository(), new ClientRepository(), new DeliveryBoyRepository(), new RestaurantRepository(), new AddressRepository())
        {
        }

        public RestaurantServices(IOrderRepository orderRepo, IClientRepository clientRepo, IDeliveryBoyRepository deliveryRepo, IRestaurantRepository restaurantRepo, IAddressRepository addressRepo)
            : base(restaurantRepo)
        {            
            _orderRepo = orderRepo;
            _deliveryRepo = deliveryRepo;
            _clientRepo = clientRepo;
            _addressRepo = addressRepo;
        }

        private IOrderRepository _orderRepo;
        private IDeliveryBoyRepository _deliveryRepo;
        private IClientRepository _clientRepo;
        private IAddressRepository _addressRepo;
        #endregion

        #region IServices<Restaurant>

        public void Add(RestaurantModel model)
        {
            Restaurant restaurant = null;
            restaurant = model.ToEntity(restaurant);
            _mainRepo.Add(restaurant);
            _mainRepo.Save();
        }

        public void Delete(RestaurantModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(RestaurantModel model)
        {
            Restaurant restaurant = _mainRepo.GetSingle(c => c.Name == model.Name);
            restaurant = model.ToEntity(restaurant);
            restaurant.Address = model.Address.ToEntity<AddressModel, Address>();
            _mainRepo.Save();
        }

        #endregion

        #region IRestaurantServices

        public bool Exists(string name)
        {
            return _mainRepo.Any(b => b.Name == name);
        }

        public RestaurantModel Get(string name)
        {
            Restaurant restaurant = _mainRepo.GetSingle(c => c.Name == name);

            if (restaurant == null)
                return null;

            return restaurant.ToModel<Restaurant,RestaurantModel>();
        }

        public IEnumerable<RestaurantModel> NearBy(AddressModel address)
        {
            var restaurants = from r in _mainRepo.GetQueryable()
                            where r.Address.PostalCode == address.PostalCode
                            select r.ToModel<Restaurant, RestaurantModel>();
            return restaurants;
        }

        #endregion
    }
}
