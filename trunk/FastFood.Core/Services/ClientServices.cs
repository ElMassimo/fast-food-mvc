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
        bool IsClient(string mail);
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
            Client client = null;
            client = model.ToEntity(client);
            _mainRepo.Add(client);
            _mainRepo.Save();
        }

        public void Delete(ClientModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(ClientModel model)
        {
            Client client = _mainRepo.GetSingle(c => c.Email == model.Email);
            client = model.ToEntity(client);
            client.Address = model.Address.ToEntity<AddressModel, Address>();
            _mainRepo.Save();
        }

        #endregion

        #region IClientServices

        public bool IsClient(string mail)
        {
            return _mainRepo.Any(c => c.Email == mail);
        }

        public ClientModel GetClient(string mail)
        {
            Client client = _mainRepo.GetSingle(c => c.Email == mail);

            if (client == null)
                return null;

            return client.ToModel<Client,ClientModel>();
        }

        #endregion
    }
}
