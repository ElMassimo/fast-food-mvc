using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FastFood.Dal.EntityModels;
using FastFood.Core.Models;
using AutoMapper;

namespace FastFood.Core.Services
{
    public class MappingServices
    {
        private static MappingServices _instance = null;

        public static MappingServices Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MappingServices();
                }
                return _instance;
            }
        }

        private MappingServices()
        {
            InitializeAddressMapping();
            InitializeClientMapping();
            InitializeDeliveryBoyMapping();
            InitializeBranchMapping();
        }

        private void InitializeAddressMapping()
        {
            Mapper.CreateMap<AddressModel, Address>();
            Mapper.CreateMap<Address, AddressModel>();
        }

        private void InitializeClientMapping()
        {
            Mapper.CreateMap<ClientModel, Client>()
                .ForMember(c => c.Address, mo => mo.Ignore())
                .ForMember(c => c.Orders, mo => mo.Ignore());
            Mapper.CreateMap<Client, ClientModel>()
                .ForMember(cm => cm.Address, mo => mo.Ignore())
                .ForMember(cm => cm.Orders, mo => mo.Ignore());
        }
        
        private void InitializeDeliveryBoyMapping()
        {
            Mapper.CreateMap<DeliveryBoyModel, DeliveryBoy>()
                .ForMember(d => d.Orders, mo => mo.Ignore());
            Mapper.CreateMap<DeliveryBoy, DeliveryBoyModel>()
                .ForMember(d => d.Orders, mo => mo.Ignore());
        }

        private void InitializeBranchMapping()
        {
            Mapper.CreateMap<BranchModel, Branch>()
                .ForMember(b => b.DeliveryBoys, mo => mo.Ignore());
            Mapper.CreateMap<Branch, BranchModel>()
                .ForMember(b => b.DeliveryBoys, mo => mo.Ignore());
        }

        public Address AddressToEntity(AddressModel model, Address address = null)
        {
            address = address ?? new Address();
            address = Mapper.Map(model, address);
            return address;
        }

        public AddressModel AddressToModel(Address address)
        {
            AddressModel model = new AddressModel();
            model = Mapper.Map(address, model);
            return model;
        }

        public Client ClientToEntity(ClientModel model, Client client = null)
        {
            client = client ?? new Client();
            client = Mapper.Map(model, client);
            return client;
        }

        public ClientModel ClientToModel(Client client)
        {
            ClientModel model = new ClientModel();
            model = Mapper.Map(client, model);
            return model;
        }

        public Branch BranchToEntity(BranchModel model, Branch branch = null)
        {
            branch = branch ?? new Branch();
            branch = Mapper.Map(model, branch);
            return branch;
        }

        public BranchModel BranchToModel(Branch branch)
        {
            BranchModel model = new BranchModel();
            model = Mapper.Map(branch, model);
            return model;
        }

        public DeliveryBoy DeliveryBoyToEntity(DeliveryBoyModel model, DeliveryBoy deliveryBoy = null)
        {
            deliveryBoy = deliveryBoy ?? new DeliveryBoy();
            deliveryBoy = Mapper.Map(model, deliveryBoy);
            return deliveryBoy;
        }

        public DeliveryBoyModel DeliveryBoyToModel(DeliveryBoy deliveryBoy)
        {
            DeliveryBoyModel model = new DeliveryBoyModel();
            model = Mapper.Map(deliveryBoy, model);
            return model;
        }
    }
}
