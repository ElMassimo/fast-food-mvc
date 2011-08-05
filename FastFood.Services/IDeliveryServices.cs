using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using FastFood.Core.Models;

namespace FastFood.Services
{
    [ServiceContract]
    public interface IDeliveryServices
    {        
        // Services for the WP7 application
        [OperationContract]
        IList<OrderHeader> GetUndeliveredOrders(string nick, string password);

        [OperationContract]
        OrderDetail GetOrderDetail(int orderId);

        [OperationContract]
        bool DeliverOrder(string nick, string password, int orderId);
    }

    [DataContract]
    public class OrderHeader
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        public OrderHeader(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    [DataContract]
    public class OrderDetail
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime DateOrdered { get; set; }

        [DataMember]
        public Decimal Cost { get; set; }

        [DataMember]
        public string Address { get; set; }
    }
}
