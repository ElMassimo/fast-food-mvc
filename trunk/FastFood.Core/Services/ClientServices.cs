using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using FastFood.Core.Models;
using FastFood.Dal.EntityModels;
using FastFood.Dal.Repositories;

namespace FastFood.Core.Services
{
    public interface IClientServices : IServices<ClientModel>
    {
        ClientModel GetClient(string mail);
    }

    public class ClientServices : BaseServices<Client, ClientModel>, IClientServices
    {
        #region Constructor / Repositories
        public ClientServices()
            : this(new OrderRepository(), new ClientRepository(), new DeliveryBoyRepository(), new BranchRepository(), new AddressRepository())
        {
        }

        public ClientServices(IOrderRepository orderRepo, IClientRepository clientRepo, IDeliveryBoyRepository deliveryRepo, IBranchRepository branchRepo, IAddressRepository addressRepo)
            : base(clientRepo)
        {            
            _orderRepo = orderRepo;
            _deliveryRepo = deliveryRepo;
            _branchRepo = branchRepo;
            _addressRepo = addressRepo;
        }

        private IOrderRepository _orderRepo;
        private IDeliveryBoyRepository _deliveryRepo;
        private IBranchRepository _branchRepo;
        private IAddressRepository _addressRepo;
        #endregion

        #region IServices<Client>

        public void Add(ClientModel model)
        {
            Client client = MappingServices.Current.ClientToEntity(model);
            client.Address = MappingServices.Current.AddressToEntity(model.Address);
            _mainRepo.Add(client);
            _mainRepo.Save();
        }

        public void Delete(ClientModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(ClientModel model)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IClientServices

        public ClientModel GetClient(string mail)
        {
            Client client = _mainRepo.GetSingle(c => c.Email == mail);
            return MappingServices.Current.ClientToModel(client);
        }

        #endregion
    }
}
