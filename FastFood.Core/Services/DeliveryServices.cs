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
        DeliveryBoyModel GetDeliveryBoy(string nick);
    }

    public class DeliveryServices : BaseServices<DeliveryBoy, DeliveryBoyModel>, IDeliveryServices
    {
        #region Constructors / Repositories

        public DeliveryServices()
            : this(new OrderRepository(), new DeliveryBoyRepository(), new DeliveryBoyRepository(), new BranchRepository(), new AddressRepository())
        {
        }

        public DeliveryServices(IOrderRepository orderRepo, IDeliveryBoyRepository clientRepo, IDeliveryBoyRepository deliveryRepo, IBranchRepository branchRepo, IAddressRepository addressRepo)
            : base(deliveryRepo)
        {
            _orderRepo = orderRepo;
            _clientRepo = clientRepo;
            _branchRepo = branchRepo;
            _addressRepo = addressRepo;
        }

        private IOrderRepository _orderRepo;
        private IDeliveryBoyRepository _clientRepo;
        private IBranchRepository _branchRepo;
        private IAddressRepository _addressRepo;

        #endregion

        #region IServices<DeliveryBoy>

        public void Add(DeliveryBoyModel model)
        {
            DeliveryBoy deliveryBoy = MappingServices.Current.DeliveryBoyToEntity(model);
            deliveryBoy.Branch = MappingServices.Current.BranchToEntity(model.Branch);
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

        public DeliveryBoyModel GetDeliveryBoy(string nick)
        {
            DeliveryBoy deliveryBoy = _mainRepo.GetSingle(d => d.Nick == nick);
            return MappingServices.Current.DeliveryBoyToModel(deliveryBoy);
        }

        #endregion
    }
}
