using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FastFood.Dal.EntityModels;
using FastFood.Core.Models;
using AutoMapper;

namespace FastFood.Core.Services
{
    public static class MappingServices
    {
        private static bool _initialized = false;

        private static void Initialize()
        {
            if (!_initialized)
            {
                InitializeAddressMapping();
                InitializeClientMapping();
                InitializeDeliveryBoyMapping();
                InitializeRestaurantMapping();
                _initialized = true;
            }
        }

        private static void InitializeAddressMapping()
        {
            Mapper.CreateMap<AddressModel, Address>();
            Mapper.CreateMap<Address, AddressModel>();
        }

        private static void InitializeClientMapping()
        {
            Mapper.CreateMap<ClientModel, Client>()
                .ForMember(c => c.Orders, mo => mo.Ignore());
            Mapper.CreateMap<Client, ClientModel>()
                .ForMember(cm => cm.Orders, mo => mo.Ignore());
        }

        private static void InitializeDeliveryBoyMapping()
        {
            Mapper.CreateMap<DeliveryBoyModel, DeliveryBoy>()
                .ForMember(d => d.Orders, mo => mo.Ignore());
            Mapper.CreateMap<DeliveryBoy, DeliveryBoyModel>()
                .ForMember(d => d.Orders, mo => mo.Ignore());
        }

        private static void InitializeRestaurantMapping()
        {
            Mapper.CreateMap<RestaurantModel, Restaurant>()
                .ForMember(b => b.DeliveryBoys, mo => mo.Ignore());
            Mapper.CreateMap<Restaurant, RestaurantModel>()
                .ForMember(b => b.DeliveryBoys, mo => mo.Ignore());
        }

        public static E ToEntity<M, E>(this M model, E entity = null) where E : class, new()
        {
            Initialize();
            entity = entity ?? new E();
            entity = Mapper.Map(model, entity);
            return entity;
        }

        public static M ToModel<E, M>(this E entity) where M : class, new()
        {
            Initialize();
            M model = new M();
            model = Mapper.Map(entity, model);
            return model;
        }
    }
}
