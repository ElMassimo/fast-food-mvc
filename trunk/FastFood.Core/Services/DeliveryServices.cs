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

    }

    public class DeliveryServices : IDeliveryServices
    {
        #region Constructors / Repositories
        public DeliveryServices()
            : this(new OrderRepository(), new ClientRepository(), new DeliveryBoyRepository(), new BranchRepository(), new AddressRepository())
        {
        }

        public DeliveryServices(IOrderRepository orderRepo, IClientRepository clientRepo, IDeliveryBoyRepository deliveryRepo, IBranchRepository branchRepo, IAddressRepository addressRepo)
        {
            _orderRepo = orderRepo;
            _clientRepo = clientRepo;
            _deliveryRepo = deliveryRepo;
            _branchRepo = branchRepo;
            _addressRepo = addressRepo;
        }

        private IOrderRepository _orderRepo;
        private IClientRepository _clientRepo;
        private IDeliveryBoyRepository _deliveryRepo;
        private IBranchRepository _branchRepo;
        private IAddressRepository _addressRepo;
        #endregion

        #region Mappers
        private void CreateMapToModel()
        {
            AutoMapper.Mapper.CreateMap<DeliveryBoy, DeliveryBoyModel>();
        }

        private void CreateMapToEntities()
        {
            AutoMapper.Mapper.CreateMap<DeliveryBoyModel, DeliveryBoy>();
        }
        #endregion
            
        public void Add(DeliveryBoyModel model)
        {
 	        throw new NotImplementedException();
        }

        public void Delete(DeliveryBoyModel model)
        {
 	        throw new NotImplementedException();
        }

        public void Update(DeliveryBoyModel model)
        {
 	        throw new NotImplementedException();
        }

        public DeliveryBoyModel GetSingle(System.Linq.Expressions.Expression<Func<DeliveryBoyModel,bool>> whereCondition)
        {
 	        throw new NotImplementedException();
        }

        public IList<DeliveryBoyModel> GetAll()
        {
 	        throw new NotImplementedException();
        }

        public IQueryable<DeliveryBoyModel> Query(System.Linq.Expressions.Expression<Func<DeliveryBoyModel,bool>> whereCondition)
        {
 	        throw new NotImplementedException();
        }
    }
}
