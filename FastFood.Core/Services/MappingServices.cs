﻿using System;
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
                InitializeOrderMapping();
                _initialized = true;
            }
        }

        private static void InitializeAddressMapping()
        {
            Mapper.CreateMap<AddressModel, Address>()
                .ForMember(a => a.State, o => o.MapFrom(m => m.State ?? m.City))
                .ForMember(a => a.PostalCode, o => o.MapFrom(m => m.PostalCode ?? 11200));
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
                .ForMember(d => d.Restaurant, mo => mo.Ignore())
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

        private static void InitializeOrderMapping()
        {
            Mapper.CreateMap<OrderModel, Order>()
                .ForMember(o => o.Client, mo => mo.Ignore())
                .ForMember(o => o.DeliveryBoy, mo => mo.Ignore());
            Mapper.CreateMap<Order, OrderModel>();

            Mapper.CreateMap<OrderStatus, Int16>()
                .ConvertUsing(os => (Int16)os);
            Mapper.CreateMap<Int16, OrderStatus>()
                .ConvertUsing(s => (OrderStatus)s);
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

        public static IList<M> ToModels<E, M>(this IEnumerable<E> entities) where M : class, new()
        {
            Initialize();
            List<M> models = new List<M>();
            return Mapper.Map(entities, models);
        }
    }
}
