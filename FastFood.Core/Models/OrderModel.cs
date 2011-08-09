using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace FastFood.Core.Models
{
    public enum OrderStatus
    {
        New = 0,
        Assigned = 1,
        OnItsWay = 2,
        Delivered = 3,
        Lost = 4
    }

    public class OrderModel
    {
        public int Id { get; set; }

        [DisplayName("Description")]
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date ordered")]
        public DateTime DateOrdered { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date delivered")]
        public DateTime? DateDelivered { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date ordered")]
        public OrderStatus Status { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Total cost")]
        public Decimal Cost { get; set; }

        public ClientModel Client { get; set; }

        public DeliveryBoyModel DeliveryBoy { get; set; }
    }
}